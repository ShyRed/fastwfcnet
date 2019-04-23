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

namespace FastWfcNet.Wfc
{
    /// <summary>
    /// Propagate information about patterns in the wave.
    /// </summary>
    public sealed class Propagator
    {
        /// <summary>
        /// The number of known patterns.
        /// </summary>
        private readonly uint _PatternsSize;

        /// <summary>
        /// propagator[pattern][direction] contains all the patterns that can
        /// be placed in next to pattern in the direction <c>direction</c>.
        /// </summary>
        private PropagatorState<uint> _PropagatorState;

        /// <summary>
        /// The width of the wave.
        /// </summary>
        private uint _WaveWidth;

        /// <summary>
        /// The height of the wave.
        /// </summary>
        private uint _WaveHeight;

        /// <summary>
        /// <c>true</c> if the wave and the output is toric.
        /// </summary>
        private bool _PeriodicOutput;

        /// <summary>
        /// All the entries that should be propagated.
        /// <para>The entry should be propagated when <c>wave[y, x, pattern]</c> is set to
        /// <c>false</c>.</para>
        /// </summary>
        private Stack<PropagationEntry> _Propagating;

        /// <summary>
        /// <c>compatible[y, x, pattern][direction]</c> contains the number of patterns
        /// present in the wave that can be placed in the cell next to(y, x) in the
        /// opposite direction of direction without being in contradiction with pattern
        /// placed in (y, x). If <c>wave[y, x, pattern]</c> is set to false, then
        /// <c>compatible[y, x, pattern]</c> has every element negative or null
        /// </summary>
        private Array3D<int[]> _Compatible;

        /// <summary>
        /// Constructor building the propagator and initializing compatible.
        /// </summary>
        /// <param name="waveHeight">The wave's height.</param>
        /// <param name="waveWidth">The wave's width.</param>
        /// <param name="periodicOutput"><c>true</c> if the wave and the output is toric.</param>
        /// <param name="propagatorState">The propagator state.</param>
        public Propagator(uint waveHeight, uint waveWidth, bool periodicOutput, PropagatorState<uint> propagatorState)
        {
            _PatternsSize = propagatorState.PatternCount;
            _WaveHeight = waveHeight;
            _WaveWidth = waveWidth;
            _PeriodicOutput = periodicOutput;
            _PropagatorState = propagatorState;
            _Propagating = new Stack<PropagationEntry>();
            _Compatible = new Array3D<int[]>(waveHeight, waveWidth, _PatternsSize);
            InitCompatible();
        }

        /// <summary>
        /// Adds an element to the propagator.
        /// <para>This function is called when <c>wave[y, x, pattern]</c>is set to <c>false</c>.</para>
        /// </summary>
        /// <param name="y">Y coordinate.</param>
        /// <param name="x">X coordinate.</param>
        /// <param name="pattern">The pattern to propagate.</param>
        public void AddToPropagator(uint y, uint x, uint pattern)
        {
            // All the direction are set to 0, since the pattern cannot be set in (y, x).
            var temp = new int[Direction.DirectionCount];
            _Compatible[y, x, pattern] = temp;
            _Propagating.Push(new PropagationEntry(x, y, pattern));
        }

        /// <summary>
        /// Propagate the information given with <c>AddToPropagator</c>.
        /// </summary>
        /// <param name="wave">The wave.</param>
        public void Propagate(Wave wave)
        {
            // We propagate every element while there is element to propagate.
            while (_Propagating.Count > 0)
            {
                var element = _Propagating.Pop();
                var y1 = element.Y;
                var x1 = element.X;
                var pattern = element.Pattern;

                // We propagate the information in all 4 directions
                for (uint direction = 0; direction < Direction.DirectionCount; direction++)
                {
                    // We get the next cell in the direction "direction"
                    var dx = Direction.DirectionsX[direction];
                    var dy = Direction.DirectionsY[direction];
                    int x2;
                    int y2;
                    if (_PeriodicOutput)
                    {
                        x2 = ((int)x1 + dx + (int)_WaveWidth) % (int)_WaveWidth;
                        y2 = ((int)y1 + dy + (int)_WaveHeight) % (int)_WaveHeight;
                    }
                    else
                    {
                        x2 = (int)x1 + dx;
                        y2 = (int)y1 + dy;
                        if (x2 < 0 || x2 >= (int)_WaveWidth || y2 < 0 || y2 >= (int)_WaveHeight)
                            continue;
                    }

                    // The index of the second cell and the patterns compatible
                    var i2 = x2 + y2 * _WaveWidth;
                    var patterns = _PropagatorState[pattern, direction];

                    // For every pattern that could be placed in that cell without being in
                    // contradiction with pattern
                    for (int i = 0; i < patterns.Count; i++)
                    {
                        var it = patterns[i];

                        // We decrease the number of compatible patterns in the opposite
                        // direction. If the pattern was discarded from the wave, the element
                        // is still negative, which is not a problem.
                        var value = _Compatible[(uint)y2, (uint)x2, it];
                        value[direction]--;

                        // If the element was set to 0 with this operation, we need to remove
                        // the pattern from the wave and propagate the information.
                        if (value[direction] == 0)
                        {
                            AddToPropagator((uint)y2, (uint)x2, it);
                            wave[(uint)i2, it] = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Build the array of compatible patterns.
        /// </summary>
        private void InitCompatible()
        {
            for (uint y = 0; y < _WaveHeight; y++)
            {
                for (uint x = 0; x < _WaveWidth; x++)
                {
                    for (uint pattern = 0; pattern < _PatternsSize; pattern++)
                    {
                        var value = new int[Direction.DirectionCount];
                        for (uint direction = 0; direction < Direction.DirectionCount; direction++)
                        {
                            value[direction] = _PropagatorState[pattern, Direction.GetOppositeDirection(direction)].Count;
                        }
                        _Compatible[y, x, pattern] = value;
                    }
                }
            }
        }
    }
}
