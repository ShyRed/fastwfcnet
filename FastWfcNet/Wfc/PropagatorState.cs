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
using System.Collections.Generic;

namespace FastWfcNet.Wfc
{
    /// <summary>
    /// Propagator state. Holds for each pattern in each direction the possible/allowed states.
    /// </summary>
    public sealed class PropagatorState
    {
        /// <summary>
        /// Returns the list of possibile patterns for the specified <c>pattern</c>
        /// in the given <c>direction</c>.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>The list of possible patterns for the given pattern and direction.</returns>
        public List<uint> this[uint pattern, uint direction]
        {
            get
            {
                return _State[pattern * Direction.DirectionCount + direction];
            }
        }

        /// <summary>
        /// The number of patterns.
        /// </summary>
        public readonly uint PatternCount;

        /// <summary>
        /// State
        /// </summary>
        private List<uint>[] _State;

        /// <summary>
        /// Creates a new <see cref="PropagatorState"/> that can hold the specified
        /// amount of patterns.
        /// </summary>
        /// <param name="patternCount">The number of patterns.</param>
        public PropagatorState(uint patternCount)
        {
            PatternCount = patternCount;
            _State = new List<uint>[patternCount * Direction.DirectionCount];
            for (int i = 0; i < patternCount * Direction.DirectionCount; i++)
                _State[i] = new List<uint>();
        }
    }
}
