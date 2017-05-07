// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 06-29-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-18-2016
// ***********************************************************************
// <copyright file="TraceHeader.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using static System.String;

namespace RefraGama.Core
{
    /// <summary>
    /// Provide the base class for any type of seismic file header.
    /// </summary>
    public class TraceHeader
    {
        /// <summary>
        /// Default constructor for TraceHeader
        /// </summary>
        public TraceHeader()
        {
            SamplingRate = 1.0f;
            Delta = 1.0f;
            Calib = 1.0f;
            Npts = 0;
            StartTime = DateTime.MinValue;
            ChannelType = ChannelType.Undefined;
            
            // default position at easting 0m, northing 0m 49S
            Position = new UtmCoordinate(0,0,49,false);
            // default instrument correction and calibration flag set to false
            InstCalibrated = false;
            InstCorrected = false;
        }

        /// <summary>
        /// Create a deep copy of this header.
        /// </summary>
        /// <returns>TraceHeader.</returns>
        public TraceHeader Clone()
        {
            return (TraceHeader) MemberwiseClone();
        }

        /// <summary>
        /// Sampling rate in hertz, default 1.00
        /// </summary>
        /// <value>The sampling rate.</value>
        public float SamplingRate { get; set; }

        /// <summary>
        /// Sample distance in seconds, default 1.00
        /// </summary>
        /// <value>The delta.</value>
        public float Delta
        {
            get { return 1.0f/SamplingRate; }
            set
            {
                SamplingRate = 1f/value;
            }
        }

        /// <summary>
        /// Calibration factor default 1.00
        /// </summary>
        /// <value>The calib.</value>
        public float Calib { get; set; }

        /// <summary>
        /// Number of sample points as provided in the header. 
        /// May not agree with the actual data length.
        /// </summary>
        /// <value>The NPTS.</value>
        public int Npts { get; set; }

        /// <summary>
        /// Date and time of the first data sample given in UTC
        /// </summary>
        /// <value>The start time.</value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Date and time of the last data sample given in UTC
        /// </summary>
        /// <value>The end time.</value>
        public DateTime EndTime
        {
            get
            {
                var span = Delta*(Npts-1);
                return StartTime + TimeSpan.FromSeconds(span);
            }
        }

        /// <summary>
        /// Network code (default is an empty string).
        /// </summary>
        /// <value>The network.</value>
        public string Network { get; set; }

        /// <summary>
        /// Location code (default is an empty string).
        /// </summary>
        /// <value>The location.</value>
        public string Location { get; set; }

        /// <summary>
        /// Station code (default is an empty string).
        /// </summary>
        /// <value>The station.</value>
        public string Station { get; set; }

        /// <summary>
        /// Channel code (default is an empty string).
        /// </summary>
        /// <value>The channel.</value>
        public string Channel { get; set; }

        /// <summary>
        /// Source name of this trace,"Net_Sta_Loc_Chan"
        /// </summary>
        /// <value>The name of the source.</value>
        public string SourceName => Join("_", Network, Station, Location, Channel);

        /// <summary>
        /// Trace channel type
        /// </summary>
        /// <value>The type of the channel.</value>
        public ChannelType ChannelType { get; set; }


        /// <summary>
        /// Gets or sets the coordinate position in real world.
        /// </summary>
        /// <value>The world position.</value>
        public WorldCoordinate Position { get; set; }

        /// <summary>
        /// Instrument correction flag
        /// </summary>
        public bool InstCorrected { get; set; }
        /// <summary>
        /// Instrument Calibration flag
        /// </summary>
        public bool InstCalibrated { get; set; }
    }

    /// <summary>
    /// Channel type on seismic trace, Z = vertical, N = North-South, E = East-West
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// Vertical Component
        /// </summary>
        Z,
        /// <summary>
        /// Horizontal Component - North
        /// </summary>
        N,
        /// <summary>
        /// Horizontal Component - East
        /// </summary>
        E,
        /// <summary>
        /// Undefined Component
        /// </summary>
        Undefined
    }
}