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
    /// Options for the overlapping WFC model.
    /// </summary>
    public sealed class OverlappingWfcOptions
    {
        /// <summary>
        /// Set to <c>true</c> if the input is toric.
        /// </summary>
        public bool PeriodicInput;

        /// <summary>
        /// Set to <c>true</c> if the output is toric.
        /// </summary>
        public bool PeriodicOutput;

        /// <summary>
        /// The height of the output in pixels.
        /// </summary>
        public uint OutputHeight;

        /// <summary>
        /// The width of the output in pixels.
        /// </summary>
        public uint OutputWidth;

        /// <summary>
        /// The number of symmetries (the order is defined in wfc).
        /// </summary>
        public uint Symmetry;

        /// <summary>
        /// Set to <c>true</c> if the ground needs to be set.
        /// </summary>
        public bool Ground;

        /// <summary>
        /// The width and height in pixel of the patterns.
        /// </summary>
        public uint PatternSize;

        /// <summary>
        /// Gets the wave height which is calculated based on the given options.
        /// </summary>
        /// <returns>The wave height.</returns>
        public uint GetWaveHeight()
        {
            return PeriodicOutput ? OutputHeight : OutputHeight - PatternSize + 1;
        }

        /// <summary>
        /// Gets the wave width which is calculated based on the given option..
        /// </summary>
        /// <returns>The wave width.</returns>
        public uint GetWaveWidth()
        {
            return PeriodicOutput ? OutputWidth : OutputWidth - PatternSize + 1;
        }
    }
}
