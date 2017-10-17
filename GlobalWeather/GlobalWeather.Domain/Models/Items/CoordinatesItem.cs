
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Coordinates.
    /// </summary>
    public struct CoordinatesItem
    {
        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        [XmlAttribute("lon")]
        public double Longitude { get; set; }

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        [XmlAttribute("lat")]
        public double Latitude { get; set; }
    }
}
