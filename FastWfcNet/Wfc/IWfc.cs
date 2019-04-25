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

namespace FastWfcNet.Wfc
{
    /// <summary>
    /// Interface for WFC implementations.
    /// </summary>
    public interface IWfc<T>
    {
        /// <summary>
        /// The underlying WFC implementation. Can be used to access and modify
        /// the wave and its patterns, for example.
        /// </summary>
        GenericWfc Wfc { get; }

        /// <summary>
        /// Runs the WFC algorithm and returns the resulting array on success
        /// or <c>null</c> on failure.
        /// </summary>
        /// <returns>The result on success or <c>null</c> on failure.</returns>
        Array2D<T> Run();

        /// <summary>
        /// Executes a single step of observing and propagating. The return
        /// value indicates if the algorithm finished with success or failure
        /// or needs additional calls to <c>RunStep</c> to progress..
        /// </summary>
        /// <returns>Result of executed observation and propagation step.</returns>
        ObserveStatus RunStep();

        /// <summary>
        /// Returns the result of the algorithm. Is called by <see cref="Run"/> automatically
        /// and usually needs to be called only when using the <see cref="RunStep"/> method
        /// instead.
        /// <para>Should not be called when the algorithm has failed.</para>
        /// </summary>
        /// <returns>The result of the algorithm.</returns>
        Array2D<T> GetResult();
    }
}
