// ***********************************************************************
// Assembly         : spectragama.core
// Author           : Adien Akhmad
// Created          : 07-01-2016
//
// Last Modified By : Adien Akhmad
// Last Modified On : 07-18-2016
// ***********************************************************************
// <copyright file="SeismographInfo.cs" company="Geoseismal">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Numerics;

namespace RefraGama.Core
{
    /// <summary>
    /// Class SeismographInfo.
    /// </summary>
    public class SeismographInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeismographInfo" /> class.
        /// </summary>
        public SeismographInfo()
        {
            Type = SeismometerType.Undefined;
            Gain = 1.0f;
            Sensitivity = 1.0f;
            Lsb = 1.0f;
            Paz = new PoleAndZero {Zeros = new Complex[] {},Poles = new Complex[] {}};
        }

        /// <summary>
        /// Name of the instrument
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Manufacturer of the instrument
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Type of the instrument
        /// </summary>
        /// <value>The type.</value>
        public SeismometerType Type { get; set; }

        /// <summary>
        /// Uri to documentation/references
        /// </summary>
        /// <value>The homepage.</value>
        public Uri DocUri { get; set; }

        /// <summary>
        /// Poles and zeros of the instrument
        /// </summary>
        /// <value>The paz.</value>
        public PoleAndZero Paz { get; set; }

        /// <summary>
        /// Sensitivity of the instrument, default = 1.0
        /// </summary>
        /// <value>The sensitivity.</value>
        public float Sensitivity { get; set; }

        /// <summary>
        /// Gain of the instrument, default = 1.0
        /// </summary>
        /// <value>The gain.</value>
        public float Gain { get; set; }

        /// <summary>
        /// Least significance byte, default = 1.0
        /// </summary>
        /// <value>The LSB.</value>
        public float Lsb { get; set; }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>SeismometerInfoBase.</returns>
        public SeismographInfo Clone()
        {
            var clone = (SeismographInfo) MemberwiseClone();
            
            var newPaz = new PoleAndZero
            {
                Zeros = new Complex[Paz.Zeros.Length],
                Poles = new Complex[Paz.Poles.Length]
            };

            Array.Copy(Paz.Zeros,newPaz.Zeros,Paz.Zeros.Length);
            Array.Copy(Paz.Poles,newPaz.Poles,Paz.Poles.Length);
            clone.Paz = newPaz;
            return clone;
        }
    }

    /// <summary>
    /// Type of Seismometer based on IRIS Channel Naming
    /// </summary>
    public enum SeismometerType
    {
        /// <summary>
        /// Undefined type seismometer
        /// </summary>
        Undefined,
        /// <summary>
        /// High gain seismometer
        /// </summary>
        HighGain,
        /// <summary>
        /// Low gain seismometer
        /// </summary>
        LowGain,
        /// <summary>
        /// Gravimeter
        /// </summary>
        Gravimeter,
        /// <summary>
        /// Mass-position seismometer
        /// </summary>
        MassPosition,
        /// <summary>
        /// Accelerometer
        /// </summary>
        Accelerometer
    }

    /// <summary>
    /// Struct Pole and Zero
    /// </summary>
    public struct PoleAndZero
    {
        /// <summary>
        /// Gets or sets the pole.
        /// </summary>
        /// <value>The pole.</value>
        public Complex[] Poles { get; set; }
        /// <summary>
        /// Gets or sets the zeros.
        /// </summary>
        /// <value>The zeros.</value>
        public Complex[] Zeros { get; set; }
    }
}