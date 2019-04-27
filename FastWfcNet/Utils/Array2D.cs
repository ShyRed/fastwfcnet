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
    /// Represent a 2D array.
    /// <para>The 2D array is stored in a single array to improve cache usage.</para>
    /// </summary>
    /// <typeparam name="T">The type a single element in this array.</typeparam>
    public sealed class Array2D<T> : IEquatable<Array2D<T>>
    {
        /// <summary>
        /// The height of the 2D array.
        /// </summary>
        public uint Height;

        /// <summary>
        /// The width of the 2D array.
        /// </summary>
        public uint Width;

        /// <summary>
        /// The array containing the data of the 2D array.
        /// </summary>
        public T[] Data;

        /// <summary>
        /// Gets / Sets the value at the given position in the 2D array.
        /// </summary>
        /// <param name="y">Must be lower than height.</param>
        /// <param name="x">Must be lower than width.</param>
        /// <returns>The value at the specified position in the 2D array.</returns>
        public T this[uint y, uint x]
        {
            get
            {
                return Data[x + y * Width];
            }
            set
            {
                Data[x + y * Width] = value;
            }
        }

        /// <summary>
        /// Builds are 2D array given its height and width.
        /// </summary>
        /// <param name="height">The 2D array height.</param>
        /// <param name="width">The 2D array width.</param>
        public Array2D(uint height, uint width)
        {
            Height = height;
            Width = width;
            Data = new T[width * height];
        }

        /// <summary>
        /// Builds are 2D array given its height and width.
        /// <para>All the array elements are initialized to <c>value</c>.</para>
        /// </summary>
        /// <param name="height">The 2D array height.</param>
        /// <param name="width">The 2D array width.</param>
        /// <param name="value">The initial value.</param>
        public Array2D(uint height, uint width, T value)
            : this(height, width)
        {
            for (uint i = 0; i < width * height; i++)
                Data[i] = value;
        }

        /// <summary>
        /// Returns the current 2D array reflected along the x axis.
        /// </summary>
        /// <returns>A copy of the current 2D array reflected along the x axis.</returns>
        public Array2D<T> Reflected()
        {
            var result = new Array2D<T>(Height, Width);
            for (uint y = 0; y < Height; y++)
            {
                for (uint x = 0; x < Width; x++)
                {
                    result[y, x] = this[y, Width - 1 - x];
                }
            }
            return result;
        }

        /// <summary>
        /// Return the current 2D array rotated 90 degress anticlockwise.
        /// </summary>
        /// <returns>A copy of the current 2D array rotated 90 degress anticlockwise.</returns>
        public Array2D<T> Rotated()
        {
            var result = new Array2D<T>(Width, Height);
            for (uint y = 0; y < Width; y++)
            {
                for (uint x = 0; x < Height; x++)
                {
                    result[y, x] = this[x, Width - 1 - y];
                }
            }
            return result;
        }

        /// <summary>
        /// Return the sub 2D array starting from (x, y) and with size (sub_width, sub_height).
        /// The current 2D array is considered toric for this operation.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="sub_width"></param>
        /// <param name="sub_height"></param>
        /// <returns></returns>
        public Array2D<T> GetSubArray(uint y, uint x, uint sub_width, uint sub_height)
        {
            var subArray = new Array2D<T>(sub_height, sub_width);
            for (uint ki = 0; ki < sub_height; ki++)
            {
                for (uint kj = 0; kj < sub_width; kj++)
                {
                    subArray[ki, kj] = this[(y + ki) % Height, (x + kj) % Width];
                }
            }
            return subArray;
        }

        /// <summary>
        /// Assigns the current matrix the specified matrix. Data-values are
        /// taken by reference.
        /// </summary>
        /// <param name="source">The source matrix.</param>
        public void AssignFrom(Array2D<T> source)
        {
            this.Height = source.Height;
            this.Width = source.Width;
            this.Data = source.Data;
        }

        /// <summary>
        /// Checks, if the specified <see cref="Array2D{T}"/> instances are equal.
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param>
        /// <returns><c>true</c> if both instances are equal.</returns>
        public static bool operator==(Array2D<T> a, Array2D<T> b)
        {
            return object.ReferenceEquals(a, b) || a.Equals(b);
        }

        /// <summary>
        /// Checks, if the specified <see cref="Array2D{T}"/> instances are not equal.
        /// </summary>
        /// <param name="a">The first instance.</param>
        /// <param name="b">The second instance.</param>
        /// <returns><c>true</c> if both instances are not equal.</returns>
        public static bool operator !=(Array2D<T> a, Array2D<T> b)
        {
            return !(object.ReferenceEquals(a, b) || a.Equals(b));
        }

        /// <summary>
        /// Checks if the specified <see cref="Array2D{T}"/> is equal to the current instance.
        /// </summary>
        /// <param name="other">The other array.</param>
        /// <returns><c>true</c> if both instances are equal.</returns>
        public bool Equals(Array2D<T> other)
        {
            if (object.ReferenceEquals(other, null) || Width != other.Width || Height != other.Height)
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
            return Equals(obj as Array2D<T>);
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
                for (int i = 0; i < Data.Length; i++)
                    hash = (hash * HashingMultiplier) ^ Data[i].GetHashCode();
                return hash;
            }
        }
    }
}
