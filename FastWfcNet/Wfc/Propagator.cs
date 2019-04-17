using FastWfcNet.Utils;
using System;
using System.Collections.Generic;

namespace FastWfcNet.Wfc
{
    /// <summary>
    /// Propagate information about patterns in the wave.
    /// </summary>
    public sealed class Propagator
    {
        private readonly UInt32 _PatternsSize;

        /// <summary>
        /// propagator[pattern][direction] contains all the patterns that can
        /// be placed in next to pattern in the direction <c>direction</c>.
        /// </summary>
        private List<UInt32>[][] _PropagatorState;

        /// <summary>
        /// The width of the wave.
        /// </summary>
        private UInt32 _WaveWidth;

        /// <summary>
        /// The height of the wave.
        /// </summary>
        private UInt32 _WaveHeight;

        /// <summary>
        /// <c>true</c> if the wave and the output is toric.
        /// </summary>
        private bool _PeriodicOutput;

        /// <summary>
        /// All the tuples (y, x, pattern) that should be propagated.
        /// <para>The tuple sohuld be propagated when <c>wave[y, x, pattern]</c> is set to
        /// <c>false</c>.</para>
        /// </summary>
        private Stack<Tuple<UInt32, UInt32, UInt32>> _Propagating;

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
        public Propagator(UInt32 waveHeight, UInt32 waveWidth, bool periodicOutput, List<UInt32>[][] propagatorState)
        {
            _PatternsSize = (UInt32)propagatorState.GetLength(0);
            _WaveHeight = waveHeight;
            _WaveWidth = waveWidth;
            _PeriodicOutput = periodicOutput;
            _PropagatorState = propagatorState;
            _Propagating = new Stack<Tuple<uint, uint, uint>>();
            _Compatible = new Array3D<int[]>(waveHeight, waveWidth, _PatternsSize);
            InitCompatible();
        }

        /// <summary>
        /// Adds an element to the propagator.
        /// <para>This function is called when <c>wave[y, x, pattern]</c>is set to <c>false</c>.</para>
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="pattern"></param>
        public void AddToPropagator(UInt32 y, UInt32 x, UInt32 pattern)
        {
            // All the direction are set to 0, since the pattern cannot be set in (y, x).
            var temp = new int[4];
            _Compatible[y, x, pattern] = temp;
            _Propagating.Push(new Tuple<uint, uint, uint>(y, x, pattern));
        }

        /// <summary>
        /// Propagate the information given with <c>AddToPropagator</c>.
        /// </summary>
        /// <param name="wave"></param>
        public void Propagate(Wave wave)
        {
            // We propagate every element while there is element to propagate.
            while (_Propagating.Count > 0)
            {
                var element = _Propagating.Pop();
                var y1 = element.Item1;
                var x1 = element.Item2;
                var pattern = element.Item3;

                // We propagate the information in all 4 directions
                for (int direction = 0; direction < 4; direction++)
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
                    var patterns = _PropagatorState[pattern][direction];

                    // For every pattern that could be placed in that cell without being in
                    // contradiction with pattern
                    foreach (var it in patterns)
                    {
                        // We decrease the number of compatible patterns in the opposite
                        // direction. If the pattern was discarded from the wave, the element
                        // is still negative, which is not a problem.
                        var value = _Compatible[(UInt32)y2, (UInt32)x2, it];
                        value[direction]--;

                        // If the element was set to 0 with this operation, we need to remove
                        // the pattern from the wave and propagate the information.
                        if (value[direction] == 0)
                        {
                            AddToPropagator((UInt32)y2, (UInt32)x2, it);
                            wave[(UInt32)i2, it] = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initialize compatible.
        /// </summary>
        private void InitCompatible()
        {
            for (UInt32 y = 0; y < _WaveHeight; y++)
            {
                for (UInt32 x = 0; x < _WaveWidth; x++)
                {
                    for (UInt32 pattern = 0; pattern < _PatternsSize; pattern++)
                    {
                        var value = new int[4];
                        for (int direction = 0; direction < 4; direction++)
                        {
                            value[direction] = _PropagatorState[pattern][Direction.GetOppositeDirection(direction)].Count;
                        }
                        _Compatible[y, x, pattern] = value;
                    }
                }
            }
        }
    }
}
