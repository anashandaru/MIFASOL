using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refragama.Signal.Filter;
using RefraGama.Core;

namespace Refragama.Signal
{
    public static class StreamSignalOperation
    {
        public static void Filter(this ISeismicStream stream, DigitalFilter filtertype)
        {
            foreach (var trace in stream.Traces)
            {
                trace.Filter(filtertype);
            }
        }
    }
}
