
namespace GlobalWeather.Domain.Models.Weather
{
    using System.Xml.Serialization;

    /// <summary>
    ///     Class Weather.
    /// </summary>
    public class WeatherModel
    {
        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        /// <value>
        ///     The city.
        /// </value>
        [XmlElement("city")]
        public CityItem City { get; set; }

        /// <summary>
        ///     Gets or sets the temperature.
        /// </summary>
        /// <value>
        ///     The temperature.
        /// </value>
        [XmlElement("temperature")]
        public TemperatureItem Temperature { get; set; }

        /// <summary>
        ///     Gets or sets the humidity.
        /// </summary>
        /// <value>
        ///     The humidity.
        /// </value>
        [XmlElement("humidity")]
        public HumidityItem Humidity { get; set; }

        /// <summary>
        ///     Gets or sets the pressure.
        /// </summary>
        /// <value>
        ///     The pressure.
        /// </value>
        [XmlElement("pressure")]
        public PressureItem Pressure { get; set; }

        /// <summary>
        ///     Gets or sets the wind.
        /// </summary>
        /// <value>
        ///     The wind.
        /// </value>
        [XmlElement("wind")]
        public WindItem Wind { get; set; }

        /// <summary>
        ///     Gets or sets the clouds.
        /// </summary>
        /// <value>
        ///     The clouds.
        /// </value>
        [XmlElement("clouds")]
        public CloudsItem Clouds { get; set; }

        /// <summary>
        ///     Gets or sets the precipitation.
        /// </summary>
        /// <value>
        ///     The precipitation.
        /// </value>
        [XmlElement("precipitation")]
        public PrecipitationItem Precipitation { get; set; }

        /// <summary>
        ///     Gets or sets the weather.
        /// </summary>
        /// <value>
        ///     The weather.
        /// </value>
        [XmlElement("weather")]
        public WeatherItem Weather { get; set; }

        /// <summary>
        ///     Gets or sets the last update.
        /// </summary>
        /// <value>
        ///     The last update.
        /// </value>
        [XmlElement("lastupdate")]
        public LastUpdateItem LastUpdate { get; set; }
    }
}
