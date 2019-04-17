using System;

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
        public UInt32[] NbPatterns;

        /// <summary>
        /// The entropy of the cell.
        /// </summary>
        public double[] Entropy;
    }
}
