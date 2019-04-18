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
    /// Struct containing the values needed to compute the entropy of all the cells.
    /// <para>This struct is updated every time the wave is changed.</para>
    /// </summary>
    public sealed class EntropyMemoisation
    {
        /// <summary>
        /// The sum of p'(pattern) * log(p'(pattern)).
        /// </summary>
        public double[] PlogPSum;

        /// <summary>
        /// The sum of p'(pattern).
        /// </summary>
        public double[] Sum;

        /// <summary>
        /// The log of sum.
        /// </summary>
        public double[] LogSum;

        /// <summary>
        /// The number of patterns present.
        /// </summary>
        public uint[] NbPatterns;

        /// <summary>
        /// The entropy of the cell.
        /// </summary>
        public double[] Entropy;
    }
}
