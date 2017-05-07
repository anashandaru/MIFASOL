// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-03-2016
// ***********************************************************************
// <copyright file="ISeismicStream.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;

namespace RefraGama.Core
{
    /// <summary>
    /// Interface ISeismicStream
    /// </summary>
    /// <seealso />
    public interface ISeismicStream : ITimeSeries<ISeismicStream>
    {
        /// <summary>
        /// Collection of trace object.
        /// </summary>
        /// <value>The traces.</value>
        IList<ISeismicTrace> Traces { get; }

        /// <summary>
        /// Add an existing stream object.
        /// </summary>
        /// <param name="stream">The stream.</param>
        void Add(ISeismicStream stream);

        /// <summary>
        /// Add an existing trace to collection;
        /// </summary>
        /// <param name="trace">The trace.</param>
        void Add(ISeismicTrace trace);

        /// <summary>
        /// Merge traces with same ID
        /// </summary>
        void Merge();

        /// <summary>
        /// Find the absolute values of each traces
        /// </summary>
        /// <returns>Array containing the abs max values.</returns>
        float[] Max();

        /// <summary>
        /// Determines whether [contains] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [contains] [the specified type]; otherwise, <c>false</c>.</returns>
        bool Contains(ChannelType type);

        /// <summary>
        /// Get the first seismictrace with the speficied channel.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ISeismicTrace.</returns>
        ISeismicTrace GetChannel(ChannelType type);

        /// <summary>
        /// Verify if all traces have the same header element value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Verify(HeaderElement element);

        /// <summary>
        /// Gets the start date time.
        /// </summary>
        /// <returns>DateTime.</returns>
        DateTime GetStartDateTime();
        
        /// <summary>
        /// Gets the end date time.
        /// </summary>
        /// <returns>DateTime.</returns>
        DateTime GetEndDateTime();

        /// <summary>
        /// Remove any invalid trace, e.g. channel code is not valid.
        /// </summary>
        void Clean();
    }

    /// <summary>
    /// Element of trace header
    /// </summary>
    public enum HeaderElement
    {
        /// <summary>
        /// Sampling rate
        /// </summary>
        SamplingRate,
        /// <summary>
        /// Number of Points
        /// </summary>
        Npts,
        /// <summary>
        /// The start time
        /// </summary>
        StartTime,
        /// <summary>
        /// The network code
        /// </summary>
        NetworkCode,
        /// <summary>
        /// The location code
        /// </summary>
        LocationCode,
        /// <summary>
        /// The station code
        /// </summary>
        StationCode,
        /// <summary>
        /// The channel code
        /// </summary>
        ChannelCode,
        /// <summary>
        /// The channel type
        /// </summary>
        ChannelType

    }
}