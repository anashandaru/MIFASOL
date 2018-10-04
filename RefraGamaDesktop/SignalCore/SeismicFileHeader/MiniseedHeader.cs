using System;

namespace RefraGama.Core.SeismicFileHeader
{
    public class MiniseedHeader : TraceHeader
    {
        /// <summary>
        /// High precision start time defined as microseconds since UNIX epoch time.
        /// </summary>
        public long HpStartTime => GetHpTime(StartTime);

        /// <summary>
        /// Get a high precision start time defined as microseconds since UNIX epoch time from given datetime.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>System.Int64.</returns>
        public static long GetHpTime(DateTime dateTime)
        {
            // time span since unix epoch in ticks
            var dt = (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;
            // 1 tick = 100 ns, 10 tick = 1 us
            return dt / 10;
        }

        /// <summary>
        /// Data quality code
        /// </summary>
        public char QualityCode { get; set; }

        /// <summary>
        /// Gets the full name of the source.
        /// </summary>
        /// <value>The full name of the source.</value>
        public string FullSourceName => QualityCode != '\0' ? base.SourceName + '_' + QualityCode : base.SourceName;

        /// <summary>
        /// Gets or sets the type of the origin sample type.
        /// This will also be used as the default sample type encoding on file export.
        /// </summary>
        /// <value>The type of the sample in origin file.</value>
        public char OriginSampleType { get; set; }
    }
}