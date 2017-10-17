
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Temperature.
    /// </summary>
    public class TemperatureItem
    {
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public double Value { get; set; }

        /// <summary>
        ///     Gets or sets the minimum.
        /// </summary>
        /// <value>
        ///     The minimum.
        /// </value>
        [XmlAttribute("min")]
        public double Min { get; set; }

        /// <summary>
        ///     Gets or sets the maximum.
        /// </summary>
        /// <value>
        ///     The maximum.
        /// </value>
        [XmlAttribute("max")]
        public double Max { get; set; }

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
