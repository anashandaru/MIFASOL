namespace RefraGama.Core
{

    /// <summary>
    /// Class WorldCoordinate. Base class for all world coordinate
    /// </summary>
    public class WorldCoordinate
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        public float Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldCoordinate"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public WorldCoordinate(float x, float y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="WorldCoordinate"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public WorldCoordinate(WorldCoordinate position)
        {
            X = position.X;
            Y = position.Y;
        }

    }

    /// <summary>
    /// Position in Mercator Projection.
    /// </summary>
    /// <seealso cref="WorldCoordinate" />
    public class UtmCoordinate : WorldCoordinate
    {

        /// <summary>
        /// Gets or sets the UTM zone.
        /// </summary>
        /// <value>The zone.</value>
        public int Zone { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether position is located at north hemisphere].
        /// </summary>
        /// <value><c>true</c> if [north hemisphere]; otherwise, <c>false</c>.</value>
        public bool NorthHemisphere { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UtmCoordinate" /> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="zone">The zone.</param>
        /// <param name="isNorthHemisphere">is located at north hemisphere</param>
        public UtmCoordinate(float x, float y, int zone, bool isNorthHemisphere) : base(x, y)
        {
            Zone = zone;
            NorthHemisphere = isNorthHemisphere;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UtmCoordinate"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="zone">The zone.</param>
        /// <param name="isNorthHemisphere">if set to <c>true</c> [is north hemisphere].</param>
        public UtmCoordinate(WorldCoordinate position, int zone, bool isNorthHemisphere) : base(position)
        {
            Zone = zone;
            NorthHemisphere = isNorthHemisphere;
        }
    }
}
