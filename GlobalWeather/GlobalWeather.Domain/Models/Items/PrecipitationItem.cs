
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Precipitation.
    /// </summary>
    public class PrecipitationItem
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
        ///     Gets or sets the mode.
        /// </summary>
        /// <value>
        ///     The mode.
        /// </value>
        [XmlAttribute("mode")]
        public string Mode { get; set; }

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
