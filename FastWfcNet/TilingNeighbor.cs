﻿/*
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
using System;

namespace FastWfcNet
{
    /// <summary>
    /// Holds 2 neighboring tiles.
    /// </summary>
    public sealed class TilingNeighbor
    {
        /// <summary>
        /// The first tile and its orientation.
        /// </summary>
        public TileWithOrientation Tile1;

        /// <summary>
        /// The second tile and its orientation.
        /// </summary>
        public TileWithOrientation Tile2;

        /// <summary>
        /// Creates a new <see cref="TilingNeighbor"/> instance with the specified tiles and
        /// orientations.
        /// </summary>
        /// <param name="tile1">The id and orientation of the first tile.</param>
        /// <param name="tile2">The id and orientation of the second tile.</param>
        public TilingNeighbor(TileWithOrientation tile1, TileWithOrientation tile2)
        {
            Tile1 = tile1 ?? throw new ArgumentNullException(nameof(tile1));
            Tile2 = tile2 ?? throw new ArgumentNullException(nameof(tile2));
        }
    }
}
