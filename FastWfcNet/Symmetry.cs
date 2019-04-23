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
using System;

namespace FastWfcNet
{
    /// <summary>
    /// The distinct symmetries of a tile.
    /// <para>It reperesents how the tile behaves when it is rotated or reflected.</para>
    /// </summary>
    public enum Symmetry
    {
        /// <summary>
        /// Intersection
        /// </summary>
        X,

        /// <summary>
        /// Oneway
        /// </summary>
        T,

        /// <summary>
        /// Bridge
        /// </summary>
        I,

        /// <summary>
        /// Corner
        /// </summary>
        L,

        /// <summary>
        /// Diagonal
        /// </summary>
        Backslash,

        /// <summary>
        /// No symmetry.
        /// </summary>
        P
    }

    /// <summary>
    /// Helper methods for symmetry.
    /// </summary>
    public static class SymmetryHelper
    {
        /// <summary>
        /// Returns the number of possible distinct orientations for a tile.
        /// <para>An orientation is a combination of rotations and reflections.</para>
        /// </summary>
        /// <param name="symmetry"></param>
        /// <returns></returns>
        public static uint NumberOfPossibleOrientations(Symmetry symmetry)
        {
            switch (symmetry)
            {
                case Symmetry.X:
                    return 1;

                case Symmetry.I:
                case Symmetry.Backslash:
                    return 2;

                case Symmetry.T:
                case Symmetry.L:
                    return 4;

                default:
                    return 8;
            }
        }

        /// <summary>
        /// Parses a symmetry.
        /// </summary>
        /// <param name="text">The text/symbol to parse.</param>
        /// <returns>The symmetry.</returns>
        public static Symmetry Parse(string text)
        {
            Symmetry result;
            if (Enum.TryParse<Symmetry>(text, true, out result))
                return result;
                    
            if (text == "/" || text == "\\")
                return Symmetry.Backslash;

            if (text == "|")
                return Symmetry.I;

            throw new ArgumentException($"Unknown Symmetry: \"{text}\"");
        }
    }
}
