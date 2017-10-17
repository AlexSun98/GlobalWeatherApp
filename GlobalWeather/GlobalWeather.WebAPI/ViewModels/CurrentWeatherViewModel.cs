using GlobalWeather.Domain.Models.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalWeather.WebAPI.Models
{
    public class CurrentWeatherViewModel
    {
        public WeatherModel Weather { get; set; }

    }
}