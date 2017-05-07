// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-03-2016
// ***********************************************************************
// <copyright file="ISeismicTrace.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace RefraGama.Core
{
    /// <summary>
    /// Interface ISeismicTrace
    /// </summary>
    /// <seealso cref="ISeismicTrace" />
    public interface ISeismicTrace : ITimeSeries<ISeismicTrace>
    {
        /// <summary>
        /// Metadata relating to the trace
        /// </summary>
        /// <value>The header.</value>
        TraceHeader Header { get; }

        /// <summary>
        /// Data samples
        /// </summary>
        /// <value>The data.</value>
        float[] Data { get; }

        /// <summary>
        /// Metadata relating to the instrument
        /// </summary>
        /// <value>The instrument.</value>
        SeismographInfo Instrument { get; set; }

        /// <summary>
        /// Verify current trace object against available meta data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Verify();

        /// <summary>
        /// Find the absolute maximum of this trace.
        /// </summary>
        /// <returns>System.Single.</returns>
        float Max();

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>ISeismicTrace.</returns>
        ISeismicTrace Clone();

        /// <summary>
        /// Slices using index.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>IEnumerable&lt;System.Single&gt;.</returns>
        float[] Slice(int start, int end);




        /// <summary>
        /// Gets the time array.
        /// </summary>
        /// <returns>System.Double[].</returns>
        double[] GetTimeArray();

        /// <summary>
        /// Gets or sets the <see cref="System.Single"/> with the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>System.Single.</returns>
        float this[int i] { get; set; }
    }
}