
namespace GlobalWeather.Domain.Models.Weather
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    ///     Class LastUpdate.
    /// </summary>
    public class LastUpdateItem
    {
        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        [XmlAttribute("value")]
        public DateTime Value { get; set; }
    }
}
