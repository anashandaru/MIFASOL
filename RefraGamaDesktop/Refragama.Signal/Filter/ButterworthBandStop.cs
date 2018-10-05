using Neuronic.Filters.Butterwoth;

namespace Refragama.Signal.Filter
{
    public class ButterworthBandStop : DigitalFilter
    {
        public ButterworthBandStop(int filterOrder, float minFreq, float maxFreq, bool zeroPhase = false)
        {
            FilterOrder = filterOrder;
            ZeroPhase = zeroPhase;
            MinCornerFrequency = minFreq;
            MaxCornerFrequency = maxFreq;
        }

        public override void ProcessSignal(float[] signal, float freqSampling)
        {
            var coeff = new BandStopButtersworthCoefficients(FilterOrder, freqSampling, MinCornerFrequency,
                MaxCornerFrequency);
            var chain = coeff.Calculate();

            // in place filtering
            if (ZeroPhase)
                chain.Filter(signal, 0, signal, 0, signal.Length);
            else
                chain.FilterOnce(signal, 0, signal, 0, signal.Length);
        }
    }
}