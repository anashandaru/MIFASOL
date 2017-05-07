// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-03-2016
// ***********************************************************************
// <copyright file="SeismicStream.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefraGama.Core
{
    /// <summary>
    ///     Class SeismicStream.
    /// </summary>
    /// <seealso cref="ISeismicStream" />
    public class SeismicStream : ISeismicStream
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SeismicStream" /> class.
        /// </summary>
        /// <param name="traces">The traces.</param>
        public SeismicStream(IList<ISeismicTrace> traces)
        {
            Traces = traces;
        }

        /// <summary>
        ///     Get the trace at specified index.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>ISeismicTrace.</returns>
        public ISeismicTrace this[int i]
        {
            get { return Traces[i]; }
            set { Traces[i] = value; }
        }

        /// <summary>
        ///     Number of trace contained in this stream.
        /// </summary>
        /// <value>The count.</value>
        public int Count => Traces.Count;

        /// <summary>
        ///     Downsample all traces by an integer factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        public void Decimate(int factor)
        {
            foreach (var trace in Traces)
            {
                trace.Decimate(factor);
            }
        }

        /// <summary>
        ///     Normalize all traces with each respective max values.
        /// </summary>
        public void Normalize()
        {
            foreach (var trace in Traces)
            {
                trace.Normalize();
            }
        }

        /// <summary>
        ///     Normalize all traces to specified values.
        /// </summary>
        /// <param name="max">Value used to normalize</param>
        public void Normalize(float max)
        {
            foreach (var t in Traces)
            {
                t.Normalize(max);
            }
        }

        /// <summary>
        ///     Remove a trend from the stream by subtracting a linear function defined by first/last sample of the trace
        /// </summary>
        public void Detrend()
        {
            foreach (var trace in Traces)
            {
                trace.Detrend();
            }
        }

        /// <summary>
        /// Cut the time series to the given start and end time.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void Trim(DateTime start, DateTime end)
        {
            foreach (var trace in Traces)
            {
                trace.Trim(start,end);
            }
        }

        /// <summary>
        ///     Collection of trace object.
        /// </summary>
        /// <value>The traces.</value>
        public IList<ISeismicTrace> Traces { get; set; }

        /// <summary>
        ///     Add an existing stream object.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void Add(ISeismicStream stream)
        {
            foreach (var seismicTrace in stream.Traces)
            {
                Traces.Add(seismicTrace);
            }
        }

        /// <summary>
        ///     Add an existing trace to collection;
        /// </summary>
        /// <param name="trace">The trace.</param>
        public void Add(ISeismicTrace trace)
        {
            Traces.Add(trace);
        }

        /// <summary>
        ///     Merge traces with same ID
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Merge()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Find the absolute values of each traces
        /// </summary>
        /// <returns>Array containing the abs max values.</returns>
        public float[] Max()
        {
            var maxValues = new float[Traces.Count];
            for (var i = 0; i < Traces.Count; i++)
            {
                var trace = Traces[i];
                maxValues[i] = trace.Max();
            }

            return maxValues;
        }

        /// <summary>
        ///     Determines whether [contains] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [contains] [the specified type]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Contains(ChannelType type)
        {
            return Traces.Any(trace => trace.Header.ChannelType == type);
        }

        /// <summary>
        /// Get seismictrace with the speficied channel. Null if not found;
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ISeismicTrace.</returns>
        public ISeismicTrace GetChannel(ChannelType type)
        {
            for (var i = 0; i < Count; i++)
            {
                if (this[i].Header.ChannelType == type)
                {
                    return this[i];
                }
            }
            return null;
        }

        /// <summary>
        ///     Verify if all traces have the same header element value.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Verify(HeaderElement element)
        {
            switch (element)
            {
                case HeaderElement.SamplingRate:
                    var sampling = this[0].Header.SamplingRate;
                    if (Traces.Any(trace => Math.Abs(trace.Header.SamplingRate - sampling) > float.Epsilon))
                        return false;
                    break;
                case HeaderElement.Npts:
                    var npts = this[0].Header.Npts;
                    if (Traces.Any(trace => trace.Header.Npts != npts))
                        return false;
                    break;
                case HeaderElement.StartTime:
                    var startTime = this[0].Header.StartTime;
                    if (Traces.Any(trace => trace.Header.StartTime != startTime))
                        return false;
                    break;
                case HeaderElement.NetworkCode:
                    var netCode = this[0].Header.Network;
                    if (Traces.Any(trace => !trace.Header.Network.Equals(netCode)))
                        return false;
                    break;
                case HeaderElement.LocationCode:
                    var locCode = this[0].Header.Location;
                    if (Traces.Any(trace => !trace.Header.Location.Equals(locCode)))
                        return false;
                    break;
                case HeaderElement.StationCode:
                    var staCode = this[0].Header.Station;
                    if (Traces.Any(trace => !trace.Header.Station.Equals(staCode)))
                        return false;
                    break;
                case HeaderElement.ChannelCode:
                    var chaCode = this[0].Header.Channel;
                    if (Traces.Any(trace => trace.Header.Channel.Equals(chaCode)))
                        return false;
                    break;
                case HeaderElement.ChannelType:
                    var channel = this[0].Header.ChannelType;
                    if (Traces.Any(trace => trace.Header.ChannelType != channel))
                        return false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(element), element, null);
            }
            return true;
        }


        /// <summary>
        /// Gets the start date time.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime GetStartDateTime()
        {
            var start = DateTime.MaxValue;
            foreach (var trace in Traces)
            {
                if (start > trace.Header.StartTime)
                {
                    start = trace.Header.StartTime;
                }
            }

            return start;
        }

        /// <summary>
        /// Gets the end date time.
        /// </summary>
        /// <returns>DateTime.</returns>
        public DateTime GetEndDateTime()
        {
            var end = DateTime.MinValue;
            foreach (var trace in Traces)
            {
                if (end < trace.Header.EndTime)
                {
                    end = trace.Header.EndTime;
                }
            }

            return end;
        }

        /// <summary>
        ///     Return a new timeseries object cut to the given start and end time.
        /// </summary>
        /// <param name="start">Specify the start time of the timeseries</param>
        /// <param name="end">Specify the end time of the timeseries</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ISeismicStream Slice(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Normalize all traces with with the maximum values of all traces.
        /// </summary>
        /// <param name="global">if set to <c>true</c> [global].</param>
        public void Normalize(bool global)
        {
            if (global)
            {
                var maxArray = Max();
                var max = maxArray.Max();
                var min = maxArray.Min();
                var absMax = Math.Abs(max) > Math.Abs(min) ? max : min;

                Normalize(absMax);
            }
            else
            {
                Normalize();
            }
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var seismicTrace in Traces)
            {
                sb.Append($"{seismicTrace}{Environment.NewLine}");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Remove any invalid trace, e.g. channel code is not valid.
        /// </summary>
        public void Clean()
        {
            foreach (var trace in Traces)
            {
                if (trace.Header.ChannelType == ChannelType.Undefined)
                {
                    Traces.Remove(trace);
                }
            }
        }
    }
}