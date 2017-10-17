using GlobalWeather.Domain;
using GlobalWeather.Domain.Interfaces.GeoInformation;
using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Domain.Models.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GlobalWeather.WebAPI.Extensions;
using System.Threading.Tasks;
using System;

namespace GlobalWeather.WebAPI.Controllers
{
    public class WeatherController : ApiController
    {
        List<string> _allCountries = new List<string>(); //simple cache 

        /// <summary>
        /// API method to get all countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/weather/getallcountries", Name = "GetAllCountries")]
        public IEnumerable<string> GetAllCountries()
        {
            if (_allCountries == null || _allCountries.Count() == 0)
            {
                var countryService = CoreServiceLocator.Current.GetInstance<INisoCountryApiService>();
                _allCountries = countryService.GetAllCountries();
            }
            return _allCountries;
        }

        [HttpGet]
        [Route("api/weather/getcitiesbycountry/{countryName}", Name = "GetCitiesByCountry")]
        public IEnumerable<string> GetCitiesByCountry(string countryName)
        {
            var weatherService = CoreServiceLocator.Current.GetInstance<IWeatherService>();
            List<CityModel> result = weatherService.SearchCityByCountry(countryName);
            return result.Select(x=>x.City).ToList();
        }

        [HttpGet]
        [Route("api/weather/getcurrentweather/{cityname}/{countryName}", Name = "GetCurrentWeather")]
        public IHttpActionResult GetCurrentWeather(string cityName, string countryName)
        {
            var weatherService = CoreServiceLocator.Current.GetInstance<IOpenWeatherMapApiService>();
            var result = weatherService.SearchCurrentWeatherByCity(cityName, countryName);
            return Handle(result);
        }

        private IHttpActionResult Handle<T>(T data) where T : class
        {
            try
            {
                if (data == null)
                    return NotFound();

                return Ok(data);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
