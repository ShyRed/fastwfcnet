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

namespace FastWfcNet.Utils
{
    /// <summary>
    /// Represent a 3D array.
    /// <para>The 3D array is stored in a signle array to improve cache usage.</para>
    /// </summary>
    /// <typeparam name="T">The type a single element in this array.</typeparam>
    public sealed class Array3D<T> : IEquatable<Array3D<T>>
    {
        /// <summary>
        /// The height of the 3D array.
        /// </summary>
        public uint Height;

        /// <summary>
        /// The width of the 3D array.
        /// </summary>
        public uint Width;

        /// <summary>
        /// The depth of the 3D array.
        /// </summary>
        public uint Depth;

        /// <summary>
        /// The array containing the data of the 3D array.
        /// </summary>
        public T[] Data;

        /// <summary>
        /// Gets / Sets the element at the specified position.
        /// </summary>
        /// <param name="i">i must be lower than height.</param>
        /// <param name="j">j must be lower than width.</param>
        /// <param name="k">k must be lower than depth.</param>
        /// <returns></returns>
        public T this[uint i, uint j, uint k]
        {
            get
            {
                return Data[i * Width * Depth + j * Depth + k];
            }
            set
            {
                Data[i * Width * Depth + j * Depth + k] = value;
            }
        }

        /// <summary>
        /// Build a 3D array given its height, width and depth.
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="depth">The depth.</param>
        public Array3D(uint height, uint width, uint depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
            Data = new T[height * width * depth];
        }

        /// <summary>
        /// Build a 3D array given its height, width and depth.
        /// <para>The array elements are initialized to <c>value</c>.</para>
        /// </summary>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="value">The initial value.</param>
        public Array3D(uint height, uint width, uint depth, T value)
            : this(height, width, depth)
        {
            for (uint i = 0; i < Data.Length; i++)
                Data[i] = value;
        }

        public bool Equals(Array3D<T> other)
        {
            if (object.ReferenceEquals(other, null) || Width != other.Width || Height != other.Height || Depth != other.Depth)
                return false;

            for (uint i = 0; i < Data.Length; i++)
                if (!Data[i].Equals(other.Data[i]))
                    return false;

            return true;
        }

        /// <summary>
        /// Checks if the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns><c>true</c>, if both objects are equal.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Array3D<T>);
        }

        /// <summary>
        /// Calculates and returns the hashcode.
        /// </summary>
        /// <returns>The hashcode.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Width.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Height.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Depth.GetHashCode();
                for (int i = 0; i < Data.Length; i++)
                    hash = (hash * HashingMultiplier) ^ Data[i].GetHashCode();
                return hash;
            }
        }
    }
}
