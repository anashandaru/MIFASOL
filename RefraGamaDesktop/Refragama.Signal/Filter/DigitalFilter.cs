namespace Refragama.Signal.Filter
{
    public abstract class DigitalFilter
    {
        protected int FilterOrder;
        protected bool ZeroPhase;
        /// <summary>
        /// Used only for low and high pass
        /// </summary>
        protected float CutOffFrequency;

        /// <summary>
        /// Used only for band pass/stop
        /// </summary>
        protected float MinCornerFrequency;
        /// <summary>
        /// Used only for band pass/stop
        /// </summary>
        protected float MaxCornerFrequency;
        public abstract void ProcessSignal(float[] signal, float freqSampling);
    }
}
