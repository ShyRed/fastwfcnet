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
using System.Collections.Generic;

namespace FastWfcNet
{
    /// <summary>
    /// A tile that can be placed on the board in <see cref="TilingWfc"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Tile<T>
    {
        /// <summary>
        /// The tile's different orientations.
        /// </summary>
        public Array2D<T>[] Data;

        /// <summary>
        /// The tile's symmetry.
        /// </summary>
        public Symmetry Symmetry;

        /// <summary>
        /// The tile's weight on the distribution of presence of tiles.
        /// </summary>
        public double Weight;

        /// <summary>
        /// Create a tile with its differents orientations, its symmetries and its
        /// weight on the distribution of tiles.
        /// </summary>
        /// <param name="data">The tile data.</param>
        /// <param name="symmetry">The symmetry.</param>
        /// <param name="weight">The weight.</param>
        public Tile(Array2D<T>[] data, Symmetry symmetry, double weight)
        {
            Data = data;
            Symmetry = symmetry;
            Weight = weight;
        }

        /// <summary>
        /// Create a tile with its base orientation, its symmetries and its
        /// weight on the distribution of tiles.
        /// <para>The other orientations are generated with its first one.</para>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="symmetry"></param>
        /// <param name="weight"></param>
        public Tile(Array2D<T> data, Symmetry symmetry, double weight)
        {
            Data = GenerateOriented(data, symmetry);
            Symmetry = symmetry;
            Weight = weight;
        }

        /// <summary>
        /// Generate the map associating an orientation id and an action to the
        /// resulting orientation id.
        /// <para>Actions 0, 1, 2, and 3 are 0°, 90°, 180°, and 270° anticlockwise rotations.</para>
        /// <para>Actions 4, 5, 6, and 7 are actions 0, 1, 2, and 3 preceded by a reflection on the x axis.</para>
        /// </summary>
        /// <param name="symmetry">The symmetry to generate the map for.</param>
        /// <returns>The generated map.</returns>
        public static uint[,] GenerateActionMap(Symmetry symmetry)
        {
            var rotationMap = GenerateRotationMap(symmetry);
            var reflectionMap = GenerateReflectionMap(symmetry);

            var size = rotationMap.Length;
            var actionMap = new uint [8, size];

            for (int i = 0; i < size; i++)
                actionMap[0, i] = (uint)i;

            for (int a = 1; a < 4; a++)
                for (int i = 0; i < size; i++)
                    actionMap[a, i] = rotationMap[actionMap[a - 1, i]];

            for (int i = 0; i < size; i++)
                actionMap[4, i] = reflectionMap[actionMap[0, i]];

            for (int a = 5; a < 8; a++)
                for (int i = 0; i < size; i++)
                    actionMap[a, i] = rotationMap[actionMap[a - 1, i]];

            return actionMap;
        }

        /// <summary>
        /// Generate the map associating an orientation id to the orientation
        /// id obtained when rotating the tile 90° anticlockwise.
        /// </summary>
        /// <param name="symmetry">The symmetry to generate the map for.</param>
        /// <returns>The generated map.</returns>
        private static uint[] GenerateRotationMap(Symmetry symmetry)
        {
            switch (symmetry)
            {
                case Symmetry.X:
                    return new uint[] { 0 };

                case Symmetry.I:
                case Symmetry.Backslash:
                    return new uint[] { 1, 0 };

                case Symmetry.T:
                case Symmetry.L:
                    return new uint[] { 1, 2, 3, 0 };

                case Symmetry.P:
                default:
                    return new uint[] { 1, 2, 3, 0, 5, 6, 7, 4 };
            }
        }

        /// <summary>
        /// Generate the map associating an orientation id to the orientation
        /// id obtained when reflecting the tile along the x axis.
        /// </summary>
        /// <param name="symmetry">The symmetry to generate the map for.</param>
        /// <returns>The generated map.</returns>
        private static uint[] GenerateReflectionMap(Symmetry symmetry)
        {
            switch (symmetry)
            {
                case Symmetry.X:
                    return new uint[] { 0};

                case Symmetry.I:
                    return new uint[] { 0, 1};

                case Symmetry.Backslash:
                    return new uint[] { 1, 0};

                case Symmetry.T:
                    return new uint[] { 0, 3, 2, 1};

                case Symmetry.L:
                    return new uint[] { 1, 0, 3, 2};

                case Symmetry.P:
                default:
                    return new uint[] { 4, 7, 6, 5, 0, 3, 2, 1};
            }
        }

        /// <summary>
        /// Generate all distincts rotations of a 2D array given its symmetries.
        /// </summary>
        /// <param name="data">The data to generate the rotations for.</param>
        /// <param name="symmetry">The symmetry.</param>
        /// <returns>Generated rotations.</returns>
        private static Array2D<T>[] GenerateOriented(Array2D<T> data, Symmetry symmetry)
        {
            var oriented = new List<Array2D<T>>();
            oriented.Add(data);

            switch (symmetry)
            {
                case Symmetry.I:
                case Symmetry.Backslash:
                    oriented.Add(data.Rotated());
                    break;

                case Symmetry.T:
                case Symmetry.L:
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    break;

                case Symmetry.P:
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated().Reflected());
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    oriented.Add(data = data.Rotated());
                    break;

                default:
                    break;
            }

            return oriented.ToArray();
        }
    }
}
