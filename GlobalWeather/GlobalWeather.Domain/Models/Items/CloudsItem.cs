namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Clouds.
    /// </summary>
    public class CloudsItem
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
        ///     Gets or sets the name (e.g. broken clouds).
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
