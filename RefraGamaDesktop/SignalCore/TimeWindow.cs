using System;
using System.IO;

namespace RefraGama.Core
{ 
    /// <summary>
    ///     Class TimeWindow. Store information of a time window
    /// </summary>
    public class TimeWindow : IComparable<TimeWindow>
    {
        //-----Sortener-----------------------------------------------------------------------------------------
        /// <summary>
        /// Set default timewindow sorting based on time window start position
        /// </summary>
        /// <param name="comparePart"></param>
        /// <returns></returns>
        public int CompareTo(TimeWindow comparePart)
        {
            return comparePart == null ? 1 : StartPosition.CompareTo(comparePart.StartPosition);
        }

//------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeWindow"/> class.
        /// </summary>
        /// <param name="deltaTime">The time delta.</param>
        /// <param name="indexStart">The index start.</param>
        /// <param name="length">The length.</param>
        public TimeWindow(float deltaTime, int indexStart, int length)
        {
            DeltaTime = deltaTime;
            StartPosition = indexStart;
            SecondsSinceT0 = StartPosition * deltaTime;
            Duration = length * deltaTime;
            Length = length;
        }

        /// <summary>
        /// Get delta time.
        /// </summary>
        /// <value>The delta time.</value>
        public float DeltaTime { get; }

        /// <summary>
        /// Gets the start position. Start position is index of the original time series samples where the time window starts.
        /// </summary>
        /// <value>The start position.</value>
        public int StartPosition { get; }

        /// <summary>
        /// Gets the end position. End position is index of the original time series samples where the time window ends.
        /// </summary>
        /// <value>The end position.</value>
        public int EndPosition => StartPosition + Length - 1;

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; }

        /// <summary>
        /// Gets the seconds since t0.
        /// </summary>
        /// <value>The seconds since t0.</value>
        public float SecondsSinceT0 { get; }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>The duration.</value>
        public float Duration { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{SecondsSinceT0} - {SecondsSinceT0 + Duration - DeltaTime} ";
        }

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>System.Byte[].</returns>
        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(DeltaTime);
                    bw.Write(StartPosition);
                    bw.Write(Length);
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deserializes the specified bytes into a new Time Window instance.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>TimeWindow.</returns>
        public static TimeWindow Deserialize(byte[] bytes)
        {
            var dt = BitConverter.ToSingle(bytes, 0);
            var sp = BitConverter.ToInt32(bytes, 4);
            var l = BitConverter.ToInt32(bytes, 8);
            return new TimeWindow(dt, sp, l);
        }
    }
}