// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-11-2016
// ***********************************************************************
// <copyright file="ITimeSeries.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace RefraGama.Core
{
    /// <summary>
    /// Interface for time series like object
    /// </summary>
    /// <typeparam name="T">Type of timeseries</typeparam>
    public interface ITimeSeries<out T>
    {
        /// <summary>
        /// Number of element contained in this object.
        /// </summary>
        /// <value>The count.</value>
        int Count { get; }

        /// <summary>
        /// Downsample the time series by an integer factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        void Decimate(int factor);

        /// <summary>
        /// Normalize the time series to its absolute maximum
        /// </summary>
        void Normalize();

        /// <summary>
        /// Normalize the time series to specified values.
        /// </summary>
        /// <param name="max">Value used to normalize</param>
        void Normalize(float max);

        /// <summary>
        /// Remove a trend from the time series by subtracting a linear function defined by first/last sample of the trace
        /// </summary>
        void Detrend();

        /// <summary>
        /// Cut the time series to the given start and end time.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        void Trim(DateTime start, DateTime end);

        /// <summary>
        /// Return a new timeseries object cut to the given start and end time.
        /// </summary>
        /// <param name="start">Specify the start time of the timeseries</param>
        /// <param name="end">Specify the end time of the timeseries</param>
        /// <returns>T.</returns>
        T Slice(DateTime start, DateTime end);
    }
}