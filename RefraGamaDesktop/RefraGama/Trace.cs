using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefraGama
{
    class Trace
    {
        private long[] _data;
        private TraceHeader _header;
        public double[] TimeArray => GetTimeArray();
        public Trace(int instrumentId, long[] data)
        {
            _data = data;
            _header = new TraceHeader(instrumentId, _data.Length);
        }

        public Trace(int instrumentId, long[] data, double samplingRate)
        {
            _data = data;
            _header = new TraceHeader(instrumentId, _data.Length);
            _header.SamplingRate = samplingRate;
        }

        public Trace(long[] data, TraceHeader header)
        {
            _data = data;
            _header = header;
        }

        /// <summary>
        /// Gets the time array in OLE Automation format. Uses DateTime ToOADate method.
        /// </summary>
        /// <returns>System.Double[].</returns>
        private double[] GetTimeArray()
        {
            var timeArray = new double[_data.Length];
            var startTime = _header.StartTime;
            var delta = _header.Delta;
            for (var i = 0; i < _data.Length; i++)
            {
                timeArray[i] = startTime.AddSeconds(delta * i).ToOADate();
            }

            return timeArray;
        }

        /// <summary>
        /// Get the trace values at specified index
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns>System.Single.</returns>
        public long this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }

        public void RemoveOffset()
        {
            var mean = (long) _data.Average();
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] -= mean;
            }
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
        public long[] Data
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return
                $"{_header.InstrumentId} | {_header.StartTime.ToString("s")} - {_header.EndTime.ToString("s")} | {_header.SamplingRate} Hz | {_header.Npts} samples";
        }
    }
}
