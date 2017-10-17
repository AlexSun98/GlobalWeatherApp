
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Humidity.
    /// </summary>
    public class HumidityItem
    {
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public int Value { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        [XmlAttribute("unit")]
        public string Unit { get; set; }
    }
}
