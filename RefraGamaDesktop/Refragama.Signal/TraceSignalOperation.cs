using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refragama.Signal.Filter;
using RefraGama.Core;

namespace Refragama.Signal
{
    public static class TraceSignalOperation
    {
        public static void Filter(this ISeismicTrace trace, DigitalFilter filterType)
        {
            filterType.ProcessSignal(trace.Data,trace.Header.SamplingRate);
        }
    }
}
