
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Wind.
    /// </summary>
    public class WindItem
    {
        /// <summary>
        ///     Gets or sets the speed.
        /// </summary>
        /// <value>
        ///     The speed.
        /// </value>
        [XmlElement("speed")]
        public SpeedItem Speed { get; set; }

        /// <summary>
        ///     Gets or sets the direction.
        /// </summary>
        /// <value>
        ///     The direction.
        /// </value>
        [XmlElement("direction")]
        public DirectionItem Direction { get; set; }
    }
}
