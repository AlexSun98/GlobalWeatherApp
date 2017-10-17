
namespace GlobalWeather.Domain.Models.Weather
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Sun.
    /// </summary>
    public class SunItem
    {
        /// <summary>
        ///     Gets or sets the sunrise time.
        /// </summary>
        /// <value>
        ///     The rise.
        /// </value>
        [XmlAttribute("rise")]
        public DateTime Rise { get; set; }

        /// <summary>
        ///     Gets or sets the sunset time.
        /// </summary>
        /// <value>
        ///     The set.
        /// </value>
        [XmlAttribute("set")]
        public DateTime Set { get; set; }
    }
}
