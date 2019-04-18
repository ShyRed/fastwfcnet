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
namespace FastWfcNet.Wfc
{
    /// <summary>
    /// A position and pattern that should be propagated.
    /// </summary>
    public struct PropagationEntry
    {
        /// <summary>
        /// X-coordinate.
        /// </summary>
        public uint X;

        /// <summary>
        /// Y-coordinate.
        /// </summary>
        public uint Y;

        /// <summary>
        /// The pattern.
        /// </summary>
        public uint Pattern;

        /// <summary>
        /// Creates a new <see cref="PropagationEntry"/> with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="pattern">The pattern.</param>
        public PropagationEntry(uint x, uint y, uint pattern)
        {
            X = x;
            Y = y;
            Pattern = pattern;
        }
    }
}
