/*
    MIT License

    Copyright (c) 2019 Pascal Richter
    Copyright (c) 2018 Mathieu Fehr and Nathanaël Courant

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE. 
*/
using FastWfcNet.Utils;
using FastWfcNet.Wfc;
using System;
using System.Collections.Generic;

namespace FastWfcNet
{
    /// <summary>
    /// Class generating a new image with the tiling WFC algorithm.
    /// </summary>
    public sealed class TilingWfc<T>
    {
        /// <summary>
        /// The distinct tiles.
        /// </summary>
        private Tile<T>[] Tiles;

        /// <summary>
        /// Map Ids of oriented tiles to tile and orientation.
        /// </summary>
        private List<Tuple<uint, uint>> IdToOrientedTile;

        /// <summary>
        /// Map tile and orientation to oriented tile id.
        /// </summary>
        private List<List<uint>> OrientedTileIds;

        /// <summary>
        /// Options needed to use the tiling WFC.
        /// </summary>
        private TilingWfcOptions Options;

        /// <summary>
        /// The underlying generic WFC algorithm.
        /// </summary>
        private GenericWfc Wfc;

        /// <summary>
        /// Creates a <see cref="TilingWfc{T}"/> instance to generate a tiled image.
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="neighbors"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="options"></param>
        /// <param name="seed"></param>
        public TilingWfc(Tile<T>[] tiles,
            List<Tuple<uint, uint, uint, uint>> neighbors,
            uint height,
            uint width,
            TilingWfcOptions options,
            int seed)
        {
            Tiles = tiles;

            var generated = GenerateOrientedTileIds(tiles);
            IdToOrientedTile = generated.Item1;
            OrientedTileIds = generated.Item2;

            Options = options;
            Wfc = new GenericWfc(options.PeriodicOutput,
                seed,
                GetTileWeights(tiles),
                GeneratePropagator(neighbors, tiles, IdToOrientedTile,
                OrientedTileIds),
                height,
                width);
        }

        /// <summary>
        /// Run the tiling wfc and return the result if the algorithm succeeded.
        /// </summary>
        /// <returns>The resulting image or <c>null</c>.</returns>
        public Array2D<T> Run()
        {
            var result = Wfc.Run();
            if (result == null)
                return null;
            return IdToTiling(result);
        }

        /// <summary>
        /// Generate mapping from id to oriented tiles and vice versa.
        /// </summary>
        /// <param name="tiles">The tiles.</param>
        /// <returns>The generated mappings.</returns>
        private static Tuple<List<Tuple<uint, uint>>, List<List<uint>>> GenerateOrientedTileIds(Tile<T>[] tiles)
        {
            var idToOrientedTile = new List<Tuple<uint, uint>>();
            var orientedTileIds = new List<List<uint>>();

            uint id = 0;
            for (uint i = 0; i < tiles.Length; i++)
            {
                orientedTileIds.Add(new List<uint>());
                for (uint j = 0; j < tiles[(int)i].Data.Length; j++)
                {
                    idToOrientedTile.Add(new Tuple<uint, uint>(i, j));
                    orientedTileIds[(int)i].Add(id);
                    id++;
                }
            }

            return new Tuple<List<Tuple<uint, uint>>, List<List<uint>>>(idToOrientedTile, orientedTileIds);
        }

        /// <summary>
        /// Generates the <see cref="PropagatorState"/> which will be used in the WFC algorithm.
        /// </summary>
        /// <param name="neighbors"></param>
        /// <param name="tiles"></param>
        /// <param name="idToOrientedTile"></param>
        /// <param name="orientedTileIds"></param>
        /// <returns></returns>
        private static PropagatorState<uint> GeneratePropagator(List<Tuple<uint, uint, uint, uint>> neighbors,
            Tile<T>[] tiles,
            List<Tuple<uint, uint>> idToOrientedTile,
            List<List<uint>> orientedTileIds)
        {
            var nbOrientedTiles = (uint)idToOrientedTile.Count;
            var densePropagator = new PropagatorState<bool>(nbOrientedTiles);
            for (uint i = 0; i < nbOrientedTiles; i++)
                for (uint d = 0; d < Direction.DirectionCount; d++)
                    densePropagator[i, d].AddRange(new bool[nbOrientedTiles]);

            foreach (var neighbor in neighbors)
            {
                uint tile1 = neighbor.Item1;
                uint orientation1 = neighbor.Item2;
                uint tile2 = neighbor.Item3;
                uint orientation2 = neighbor.Item4;

                var actionMap1 = Tile<T>.GenerateActionMap(tiles[(int)tile1].Symmetry);
                var actionMap2 = Tile<T>.GenerateActionMap(tiles[(int)tile2].Symmetry);

                void add(uint action, uint direction)
                {
                    // Ignore neighbors that reference non-existing orientations
                    if (orientation1 > actionMap1.GetLength(1) || orientation2 > actionMap2.GetLength(1))
                        return;

                    uint tempOrientation1 = actionMap1[action, (int)orientation1];
                    uint tempOrientation2 = actionMap2[action, (int)orientation2];
                    uint orientedTileId1 = orientedTileIds[(int)tile1][(int)tempOrientation1];
                    uint orientedTileId2 = orientedTileIds[(int)tile2][(int)tempOrientation2];
                    densePropagator[orientedTileId1, direction][(int)orientedTileId2] = true;
                    direction = Direction.GetOppositeDirection(direction);
                    densePropagator[orientedTileId2, direction][(int)orientedTileId1] = true;
                }

                add(0, 2);
                add(1, 0);
                add(2, 1);
                add(3, 3);
                add(4, 1);
                add(5, 3);
                add(6, 2);
                add(7, 0);
            }

            var propagator = new PropagatorState<uint>(nbOrientedTiles);

            for (uint i = 0; i < nbOrientedTiles; i++)
                for (uint j = 0; j < nbOrientedTiles; j++)
                    for (uint d = 0; d < Direction.DirectionCount; d++)
                        if (densePropagator[i, d][(int)j])
                            propagator[i, d].Add(j);

            return propagator;
        }

        /// <summary>
        /// Get probability of presence of tiles.
        /// </summary>
        /// <param name="tiles">The tiles.</param>
        /// <returns>The weights.</returns>
        private static double[] GetTileWeights(Tile<T>[] tiles)
        {
            var frequencies = new List<double>();
            for (int i = 0; i < tiles.Length; i++)
                for (int j = 0; j < tiles[i].Data.Length; j++)
                    frequencies.Add(tiles[i].Weight / tiles[i].Data.Length);
            return frequencies.ToArray();
        }

        /// <summary>
        /// Translate the generic WFC result into the image result.
        /// </summary>
        /// <param name="ids">WFC result.</param>
        /// <returns>Image result.</returns>
        private Array2D<T> IdToTiling(Array2D<uint> ids)
        {
            var size = Tiles[0].Data[0].Height;
            var tiling = new Array2D<T>(size * ids.Height, size * ids.Width);

            for (uint i = 0; i < ids.Height; i++)
            {
                for (uint j = 0; j < ids.Width; j++)
                {
                    var orientedTile = IdToOrientedTile[(int)ids[i, j]];

                    for (uint y = 0; y < size; y++)
                        for (uint x = 0; x < size; x++)
                            tiling[i * size + y, j * size + x] = Tiles[orientedTile.Item1].Data[(int)orientedTile.Item2][y, x];
                }
            }

            return tiling;
        }
    }
}
