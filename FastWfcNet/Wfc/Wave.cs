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
    /// Contains the pattern possibilities in every cell.
    /// <para>Also contains information about cell entropy.</para>
    /// </summary>
    public sealed class Wave
    {
        /// <summary>
        /// The wave's width.
        /// </summary>
        public readonly uint Width;

        /// <summary>
        /// The wave's height.
        /// </summary>
        public readonly uint Height;

        /// <summary>
        /// The wave's area (result of width * height).
        /// </summary>
        public readonly uint Size;

        /// <summary>
        /// Return <c>true</c> if the pattern can be placed in cell index.
        /// </summary>
        /// <param name="index">Cell index.</param>
        /// <param name="pattern">Pattern.</param>
        /// <returns><c>true</c> if the pattern can be placed in cell index.</returns>
        public bool this[uint index, uint pattern]
        {
            get
            {
                return _Data[index, pattern];
            }
            set
            {
                var oldValue = _Data[index, pattern];
                if (oldValue == value)
                    return;

                _Data[index, pattern] = value;
                _Memoisation.PlogPSum[index] -= _PlogPPatternsFrequencies[pattern];
                _Memoisation.Sum[index] -= _PatternsFrequencies[pattern];
                _Memoisation.LogSum[index] = Math.Log(_Memoisation.Sum[index]);
                _Memoisation.NbPatterns[index] -= 1;
                _Memoisation.Entropy[index] = _Memoisation.LogSum[index] - _Memoisation.PlogPSum[index] / _Memoisation.Sum[index];

                // If there is no patterns possible in the cell, then there is a contradiction
                if (_Memoisation.NbPatterns[index] == 0)
                    _IsImpossible = true;
            }
        }

        /// <summary>
        /// Return <c>true</c> if pattern can be placed in cell (i, j).
        /// </summary>
        /// <param name="i">I coordinate.</param>
        /// <param name="j">J coordinate.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns><c>true</c> if pattern can be placed in cell (i, j).</returns>
        public bool this[uint i, uint j, uint pattern]
        {
            get
            {
                return _Data[i * Width + j, pattern];
            }
            set
            {
                this[i * Width + j, pattern] = value;
            }
        }

        /// <summary>
        /// The patterns frequencies p given to wfc.
        /// </summary>
        private double[] _PatternsFrequencies;

        /// <summary>
        /// The precomputation of p * log(p).
        /// </summary>
        private double[] _PlogPPatternsFrequencies;

        /// <summary>
        /// The precomputation of min (p * log(p)) / 2.
        /// <para>This is used to define the maximum value of the noise.</para>
        /// </summary>
        private double _MinAbsHalfPlogP;

        /// <summary>
        /// The memoisation of important values for the computation of entropy.
        /// </summary>
        private readonly EntropyMemoisation _Memoisation;

        /// <summary>
        /// This value is set to <c>true</c> if there is a contradiction in the wave (all
        /// elements set to false in a cell).
        /// </summary>
        private bool _IsImpossible;

        /// <summary>
        /// The number of distinct patterns.
        /// </summary>
        private uint _NbPatterns;

        /// <summary>
        /// The actual wave. <c>_Data[index, pattern]</c> is equal to 0 if the pattern can
        /// be placed in the cell index.
        /// </summary>
        private Array2D<bool> _Data;

        /// <summary>
        /// Initialize the wave with every cell being able to have every pattern.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="patternsFrequencies">The patterns frequencies p given to wfc.</param>
        public Wave(uint height, uint width, double[] patternsFrequencies)
        {
            _PatternsFrequencies = patternsFrequencies;
            _PlogPPatternsFrequencies = GetPlogP(patternsFrequencies);
            _MinAbsHalfPlogP = GetMinAbsHalf(_PlogPPatternsFrequencies);
            _IsImpossible = false;
            _NbPatterns = (uint)patternsFrequencies.Length;
            _Data = new Array2D<bool>(width * height, _NbPatterns, true);
            Width = width;
            Height = height;
            Size = height * width;

            // Initialize the memoisation of entropy
            var baseEntropy = 0.0;
            var baseS = 0.0;
            for (int i = 0; i < _NbPatterns; i++)
            {
                baseEntropy += _PlogPPatternsFrequencies[i];
                baseS += patternsFrequencies[i];
            }
            var logBaseS = Math.Log(baseS);
            var entropyBase = logBaseS - baseEntropy / baseS;

            _Memoisation = new EntropyMemoisation
            {
                PlogPSum = new double[width * height],
                Sum = new double[width * height],
                LogSum = new double[width * height],
                NbPatterns = new uint[width * height],
                Entropy = new double[width * height]
            };

            for (int i = 0; i < width * height; i++)
            {
                _Memoisation.PlogPSum[i] = baseEntropy;
                _Memoisation.Sum[i] = baseS;
                _Memoisation.LogSum[i] = logBaseS;
                _Memoisation.NbPatterns[i] = _NbPatterns;
                _Memoisation.Entropy[i] = entropyBase;
            }
        }

        /// <summary>
        /// Return the index of the cell with lowest entropy different of 0.
        /// <para>If there is a contradiction in the wave, return -2.</para>
        /// <para>If every cell is decided, return -1.</para>
        /// </summary>
        /// <param name="gen">The random number generator.</param>
        /// <returns>Index of the cell with lowest entropy different of 0.</returns>
        public int GetMinEntropy(Random gen)
        {
            if (_IsImpossible)
                return -2;

            // The minimum entropy (plus a small noise)
            var min = double.MaxValue;
            var argmin = -1;

            for (int i = 0; i < Size; i++)
            {
                // If the cell is decided, we do not compute the entropy (which is equal
                // to 0).
                var nbPatterns = _Memoisation.NbPatterns[i];
                if (nbPatterns == 1)
                    continue;

                // Otherwise, we take the memoised entropy
                var entropy = _Memoisation.Entropy[i];

                // We first check if the entropy is less than the minimum.
                // This is important to reduce noise computation (which is not
                // negligible).
                if (entropy < min)
                {
                    // Then, we add noise to decide randomly which will be chosen.
                    // noise is smaller than the smallest p * log(p), so the minimum
                    // entropy will always be chosen.
                    var noise = gen.NextDouble() * _MinAbsHalfPlogP;
                    if (entropy + noise < min)
                    {
                        min = entropy + noise;
                        argmin = i;
                    }
                }
            }

            return argmin;
        }

        /// <summary>
        /// Calculates and returns <c>distribution * log(distribution)</c>.
        /// </summary>
        /// <param name="distribution">Distribution.</param>
        /// <returns>distribution * log(distribution)</returns>
        private static double[] GetPlogP(double[] distribution)
        {
            var plogp = new double[distribution.Length];
            for (int i = 0; i < distribution.Length; i++)
                plogp[i] = distribution[i] * Math.Log(distribution[i]);
            return plogp;
        }

        /// <summary>
        /// Return <c>min(v) / 2</c>.
        /// </summary>
        /// <param name="v">v</param>
        /// <returns>min(v) / 2</returns>
        private static double GetMinAbsHalf(double[] v)
        {
            var minAbsHalf = double.MaxValue;
            for (int i = 0; i < v.Length; i++)
                minAbsHalf = Math.Min(minAbsHalf, Math.Abs(v[i]) / 2.0);
            return minAbsHalf;
        }
    }
}
