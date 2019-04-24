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
namespace FastWfcNet
{
    /// <summary>
    /// Holds 2 neighboring tiles.
    /// </summary>
    public sealed class TilingNeighbor
    {
        /// <summary>
        /// The id of the first tile.
        /// </summary>
        public uint Tile1;

        /// <summary>
        /// The orientation of the first tile.
        /// </summary>
        public uint Orientation1;

        /// <summary>
        /// The id of the second tile.
        /// </summary>
        public uint Tile2;

        /// <summary>
        /// The orientation of the second tile.
        /// </summary>
        public uint Orientation2;

        /// <summary>
        /// Creates a new <see cref="TilingNeighbor"/> instance with both tile ids and both
        /// orientations set to <c>0</c>.
        /// </summary>
        public TilingNeighbor()
        {
            // Nothing
        }

        /// <summary>
        /// Creates a new <see cref="TilingNeighbor"/> instance with the specified tiles and
        /// orientations.
        /// </summary>
        /// <param name="tile1">The id of the first tile.</param>
        /// <param name="orientation1">The orientation of the first tile.</param>
        /// <param name="tile2">The id of the second tile.</param>
        /// <param name="orientation2">The orientation of the second tile.</param>
        public TilingNeighbor(uint tile1, uint orientation1, uint tile2, uint orientation2)
        {
            Tile1 = tile1;
            Orientation1 = orientation1;
            Tile2 = tile2;
            Orientation2 = orientation2;
        }
    }
}
