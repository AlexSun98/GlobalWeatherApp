
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Direction.
    /// </summary>
    public class DirectionItem
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
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        [XmlAttribute("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
