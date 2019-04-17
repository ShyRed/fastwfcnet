using FastWfcNet.Utils;
using System;
using System.Collections.Generic;

namespace FastWfcNet.Wfc
{
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
        private UInt32 _NbPatterns;

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
            List<UInt32>[][] propagatorState, UInt32 waveHeight, UInt32 waveWidth)
        {
            _Gen = new Random(seed);
            _PatternsFrequencies = Normalize(patternFrequencies);
            _Wave = new Wave(waveHeight, waveWidth, _PatternsFrequencies);
            _NbPatterns = (UInt32)propagatorState.Length;
            _Propagator = new Propagator(waveHeight, waveWidth, periodicOutput, propagatorState);
        }

        /// <summary>
        /// Run the algorithm and return result if it succeeded.
        /// </summary>
        /// <returns></returns>
        public Array2D<UInt32> Run()
        {
            var status = ObserveStatus.ToContinue;
            while(true)
            {
                status = Observe();
                if (status != ObserveStatus.ToContinue)
                    break;

                _Propagator.Propagate(_Wave);
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
            for (UInt32 k = 0; k < _NbPatterns; k++)
                s += _Wave[(UInt32)argmin, k] ? _PatternsFrequencies[k] : 0;

            var randomValue = _Gen.NextDouble() * s;
            UInt32 chosenValue = _NbPatterns - 1;

            for (UInt32 k = 0; k < _NbPatterns; k++)
            {
                randomValue -= _Wave[(UInt32)argmin, k] ? _PatternsFrequencies[k] : 0;
                if (randomValue <= 0)
                {
                    chosenValue = k;
                    break;
                }
            }

            // And define the cell with the pattern
            for (UInt32 k = 0; k < _NbPatterns; k++)
            {
                if (_Wave[(UInt32)argmin, k] != (k == chosenValue))
                {
                    _Propagator.AddToPropagator((UInt32)(argmin / _Wave.Width), (UInt32)(argmin % _Wave.Width), k);
                    _Wave[(UInt32)argmin, k] = false;
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
        /// <param name="i">I coordinate.</param>
        /// <param name="j">J coordinate.</param>
        /// <param name="pattern">The pattern to remove.</param>
        public void RemoveWavePattern(UInt32 i, UInt32 j, UInt32 pattern)
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
        public Array2D<UInt32> WaveToOutput()
        {
            var outputPatterns = new Array2D<UInt32>(_Wave.Height, _Wave.Width);
            for (UInt32 i = 0; i < _Wave.Size; i++)
            {
                for (UInt32 k = 0; k < _NbPatterns; k++)
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
            foreach (var weight in v)
                sumWeights += weight;

            double invSumWeights = 1.0 / sumWeights;
            for (int i = 0; i < v.Length; i++)
                v[i] *= invSumWeights;
            return v;
        }
    }
}
