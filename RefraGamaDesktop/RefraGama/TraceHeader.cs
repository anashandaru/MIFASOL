using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefraGama
{
    class TraceHeader
    {
        public TraceHeader(int instrumentId, long npts)
        {
            InstrumentId = instrumentId;
            Npts = npts;
        }

        public int InstrumentId { get; private set; }
        public double SamplingRate { get; set; }
        public double Delta
        {
            get { return 1.0f / SamplingRate; }
            set
            {
                SamplingRate = 1f / value;
            }
        }
        public long Npts { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime
        {
            get
            {
                var span = Delta * (Npts - 1);
                return StartTime + TimeSpan.FromSeconds(span);
            }
        }

        public Position Position { get; set; }
    }

    public struct Position
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
