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
using System;

namespace FastWfcNet.Wfc
{
    /// <summary>
    /// Base WFC algorithm.
    /// </summary>
    public sealed class GenericWfc
    {
        /// <summary>
        /// The random number generator.
        /// </summary>
        private Random _Gen;

        /// <summary>
        /// The distribution of the patterns as given in input.
        /// </summary>
        private double[] _PatternsFrequencies;

        /// <summary>
        /// The wave, indicating which patterns can be put in which cell.
        /// </summary>
        private Wave _Wave;

        /// <summary>
        /// The number of distinct patterns.
        /// </summary>
        private uint _NbPatterns;

        /// <summary>
        /// The propagator, used to propagate the information in the wave.
        /// </summary>
        private Propagator _Propagator;

        /// <summary>
        /// Basic constructor initializing the algorithm.
        /// </summary>
        /// <param name="periodicOutput"><c>true</c> if the wave and the output is toric.</param>
        /// <param name="seed">Random number generator seed.</param>
        /// <param name="patternFrequencies">The pattern frequencies.</param>
        /// <param name="propagatorState">The propagator state.</param>
        /// <param name="waveHeight">The wave's height.</param>
        /// <param name="waveWidth">The wave's width.</param>
        public GenericWfc(bool periodicOutput, int seed, double[] patternFrequencies,
            PropagatorState<uint> propagatorState, uint waveHeight, uint waveWidth)
        {
            _Gen = new Random(seed);
            _PatternsFrequencies = Normalize(patternFrequencies);
            _Wave = new Wave(waveHeight, waveWidth, _PatternsFrequencies);
            _NbPatterns = propagatorState.PatternCount;
            _Propagator = new Propagator(waveHeight, waveWidth, periodicOutput, propagatorState);
        }

        /// <summary>
        /// Run the algorithm and return result if it succeeded.
        /// </summary>
        /// <returns></returns>
        public Array2D<uint> Run()
        {
            var status = Observe();
            while (status == ObserveStatus.ToContinue)
            {
                _Propagator.Propagate(_Wave);
                status = Observe();
            }
            return status == ObserveStatus.Sucess ? WaveToOutput() : null;
        }

        /// <summary>
        /// Define the value of the cell with lowest entropy.
        /// </summary>
        /// <returns>Result of the observation.</returns>
        public ObserveStatus Observe()
        {
            // Get the cell with lowest entropy.
            var argmin = _Wave.GetMinEntropy(_Gen);

            // If there is a contradiction, the algorithm has failed
            if (argmin == -2)
                return ObserveStatus.Failure;

            // If the lowest entropy is 0, then the algorithm has succeeded and
            // finished
            if (argmin == -1)
                return ObserveStatus.Sucess;

            // Choose an element according to the pattern distribution
            var s = 0.0;
            for (uint k = 0; k < _NbPatterns; k++)
                s += _Wave[(uint)argmin, k] ? _PatternsFrequencies[k] : 0;

            var randomValue = _Gen.NextDouble() * s;
            uint chosenValue = _NbPatterns - 1;

            for (uint k = 0; k < _NbPatterns; k++)
            {
                randomValue -= _Wave[(uint)argmin, k] ? _PatternsFrequencies[k] : 0;
                if (randomValue <= 0)
                {
                    chosenValue = k;
                    break;
                }
            }

            // And define the cell with the pattern
            for (uint k = 0; k < _NbPatterns; k++)
            {
                if (_Wave[(uint)argmin, k] != (k == chosenValue))
                {
                    _Propagator.AddToPropagator((uint)(argmin / _Wave.Width), (uint)(argmin % _Wave.Width), k);
                    _Wave[(uint)argmin, k] = false;
                }
            }

            return ObserveStatus.ToContinue;
        }

        /// <summary>
        /// Propagate the information of the wave.
        /// </summary>
        public void Propagate()
        {
            _Propagator.Propagate(_Wave);
        }

        /// <summary>
        /// Remove pattern from cell (i, j).
        /// </summary>
        /// <param name="i">Y coordinate.</param>
        /// <param name="j">X coordinate.</param>
        /// <param name="pattern">The pattern to remove.</param>
        public void RemoveWavePattern(uint i, uint j, uint pattern)
        {
            if (_Wave[i, j, pattern])
            {
                _Wave[i, j, pattern] = false;
                _Propagator.AddToPropagator(i, j, pattern);
            }
        }

        /// <summary>
        /// Transform the wave to a valid output (a 2D array of patterns that aren't in
        /// contradiction). This function should be used only when all cell of the wave
        /// are defined.
        /// </summary>
        /// <returns>The output.</returns>
        public Array2D<uint> WaveToOutput()
        {
            var outputPatterns = new Array2D<uint>(_Wave.Height, _Wave.Width);
            for (uint i = 0; i < _Wave.Size; i++)
            {
                for (uint k = 0; k < _NbPatterns; k++)
                {
                    if (_Wave[i, k])
                        outputPatterns.Data[i] = k;
                }
            }
            return outputPatterns;
        }

        /// <summary>
        /// Normalize a vector so the sum of its elements is equal to 1.0.
        /// </summary>
        /// <param name="v">The vector.</param>
        /// <returns>The normalized vector.</returns>
        private double[] Normalize(double[] v)
        {
            double sumWeights = 0.0;
            for (int i = 0; i < v.Length; i++)
                sumWeights += v[i];

            double invSumWeights = 1.0 / sumWeights;
            for (int i = 0; i < v.Length; i++)
                v[i] *= invSumWeights;
            return v;
        }
    }
}
