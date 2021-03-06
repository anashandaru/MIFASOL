﻿using Neuronic.Filters.Butterwoth;

namespace Refragama.Signal.Filter
{
    public class ButterworthHighPass : DigitalFilter
    {
        public ButterworthHighPass(int filterOrder, float cutOffFrequency, bool zeroPhase = false)
        {
            FilterOrder = filterOrder;
            CutOffFrequency = cutOffFrequency;
            ZeroPhase = zeroPhase;
        }

        public override void ProcessSignal(float[] signal, float freqSampling)
        {
            var coeff = new HighPassButtersworthCoefficients(FilterOrder, freqSampling, CutOffFrequency);
            var chain = coeff.Calculate();

            // in place filtering
            if (ZeroPhase)
                chain.Filter(signal, 0, signal, 0, signal.Length);
            else
                chain.FilterOnce(signal, 0, signal, 0, signal.Length);
        }
    }
}