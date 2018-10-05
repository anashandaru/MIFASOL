// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-18-2016
// ***********************************************************************
// <copyright file="SeismicTrace.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefraGama.Core
{
    /// <summary>
    /// Time series signal that contains seismic data with metadata.
    /// </summary>
    /// <seealso cref="Spectragama.Core.ISeismicTrace" />
    /// <seealso cref="ISeismicTrace" />
    public class SeismicTrace : ISeismicTrace
    {
        /// <summary>
        /// The _data
        /// </summary>
        private float[] _data;
        /// <summary>
        /// The _header
        /// </summary>
        private TraceHeader _header;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeismicTrace" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public SeismicTrace(float[] data)
        {
            _data = data;
            _header = new TraceHeader { Npts = _data.Length };
            Instrument = new SeismographInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeismicTrace" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="header">The header.</param>
        public SeismicTrace(float[] data, TraceHeader header)
        {
            _data = data;
            _header = header;
            Instrument = new SeismographInfo();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeismicTrace" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="header">The header.</param>
        /// <param name="seisInfo">The seis information.</param>
        public SeismicTrace(float[] data, TraceHeader header, SeismographInfo seisInfo)
        {
            _data = data;
            _header = header;
            Instrument = seisInfo;
        }

        /// <summary>
        /// Slices using index.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>IEnumerable&lt;System.Single&gt;.</returns>
        public float[] Slice(int start, int end)
        {
            var result = new float[end - start + 1];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = this[start + i];
            }

            return result;  
        }

        /// <summary>
        /// Gets the time array in OLE Automation format. Uses DateTime ToOADate method.
        /// </summary>
        /// <returns>System.Double[].</returns>
        public double[] GetTimeArray()
        {
            var timeArray = new double[Data.Length];
            var startTime = Header.StartTime;
            var delta = Header.Delta;
            for (var i = 0; i < Data.Length; i++)
            {
                timeArray[i] = startTime.AddSeconds(delta*i).ToOADate();
            }

            return timeArray;
        }

        /// <summary>
        /// Get the trace values at specified index
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>System.Single.</returns>
        public float this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }

        /// <summary>
        /// Downsample the trace by an integer factor.
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <exception cref="System.ArgumentException">Factor cannot be zero or negative.</exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Decimate(int factor)
        {
            if (factor <= 0)
            {
                throw new ArgumentException("Factor cannot be zero or negative.");
            }
            if (factor == 1)
            {
                return;
            }
            Data = TakeEvery(_data,factor).ToArray();
            _header.Delta *= factor;
        }

        /// <summary>
        /// Takes the every.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="m">The m.</param>
        /// <returns>IEnumerable&lt;System.Single&gt;.</returns>
        private static IEnumerable<float> TakeEvery(IReadOnlyList<float> data, int m)
        {
            for (var i = 0; i < m; i++)
            {
                if (i%m == 0)
                {
                    yield return data[i];
                }
            }
        }

        /// <summary>
        /// Normalize the trace to its absolute maximum
        /// </summary>
        public void Normalize()
        {
            var max = _data.Max();
            Normalize(max);
        }

        /// <summary>
        /// Normalize the trace to specified values.
        /// </summary>
        /// <param name="max">Value used to normalize</param>
        public void Normalize(float max)
        {
            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] /= max;
            }
        }


        /// <summary>
        /// Remove a trend from the trace by subtracting a mean value
        /// </summary>
        public void Detrend()
        {
            var average = _data.Average();

            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] -= average;
            }
        }

        /// <summary>
        /// Cut the trace to the given start and end time.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Trim(DateTime start, DateTime end)
        {
            var startIndex = Time2Index(start);
            var endIndex = Time2Index(end);
            Trim(startIndex,endIndex);
        }


        /// <summary>
        /// Cut the trace to the given start and end index.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        public void Trim(int start, int end)
        {
            var trimmed = _data.Skip(start).Take(end - start+1);
            Data = trimmed.ToArray();
            _header.StartTime = _header.StartTime.AddSeconds(_header.Delta*start);
        }


        /// <summary>
        /// Return the index of data points nearest, earlier of the specified time in the trace.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The time specified does not exist in current trace.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The time specified does not exist in current trace.</exception>
        public int Time2Index(DateTime time)
        {
            if (time < _header.StartTime || time > _header.EndTime)
            {
                throw new ArgumentOutOfRangeException(nameof(time),"The time specified does not exist in current trace.");
            }

            var span = (time - _header.StartTime).TotalSeconds;
            return (int) (span/_header.Delta);
        }


        /// <summary>
        /// Metadata relating to the trace
        /// </summary>
        /// <value>The header.</value>
        public TraceHeader Header
        {
            get { return _header; }
            set
            {
                _header = value;
                _header.Npts = _data.Length;
            }
        }

        /// <summary>
        /// Data samples
        /// </summary>
        /// <value>The data.</value>
        public float[] Data
        {
            get { return _data; }

            // the setter should always update npts header
            set
            {
                _data = value;
                Header.Npts = _data.Length;
            }
        }

        /// <summary>
        /// Metadata relating to the instrument
        /// </summary>
        /// <value>The instrument.</value>
        public SeismographInfo Instrument { get; set; }

        /// <summary>
        /// Return number of data samples of the current trace.
        /// </summary>
        /// <value>Number of data samples.</value>
        public int Count => _data.Length;

        /// <summary>
        /// Verify current trace object against available meta data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Verify()
        {
            return _data.Length == _header.Npts;
        }

        /// <summary>
        /// Find the absolute maximum of this trace.
        /// </summary>
        /// <returns>System.Single.</returns>
        public float Max()
        {
            var max = _data.Max();
            var min = _data.Min();

            return Math.Abs(max) > Math.Abs(min) ? max : min;
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>ISeismicTrace.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ISeismicTrace Clone()
        {
            var arr = new float[Count];
            Array.Copy(_data,arr,Count);

            var trace = new SeismicTrace(arr, Header.Clone(),Instrument.Clone());
            return trace;
        }

        /// <summary>
        /// Return a new trace object cut to the given start and end time.
        /// </summary>
        /// <param name="start">Specify the start time of the trace</param>
        /// <param name="end">Specify the end time of the trace</param>
        /// <returns>T.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ISeismicTrace Slice(DateTime start, DateTime end)
        {
            var clone = Clone();
            clone.Trim(start,end);
            return clone;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return
                $"{_header.SourceName} | {_header.StartTime.ToString("s")} - {_header.EndTime.ToString("s")} | {_header.SamplingRate} Hz | {_header.Npts} samples";
        }
    }
}