using System.Xml.Serialization;

namespace GlobalWeather.Domain.Models.Weather
{
    public class CityItem
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the coordinates.
        /// </summary>
        /// <value>
        ///     The coordinates.
        /// </value>
        [XmlElement("coord")]
        public CoordinatesItem Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets the sun.
        /// </summary>
        /// <value>
        ///     The sun.
        /// </value>
        [XmlElement("sun")]
        public SunItem Sun { get; set; }

        /// <summary>
        ///     Gets or sets the sun.
        /// </summary>
        /// <value>
        ///     The sun.
        /// </value>
        [XmlElement("country")]
        public string Country { get; set; }
    }
}
