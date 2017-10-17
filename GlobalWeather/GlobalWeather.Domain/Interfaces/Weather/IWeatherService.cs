using GlobalWeather.Domain.Models.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalWeather.Domain.Interfaces.Weather
{
    public interface IWeatherService
    {
        List<CityModel> SearchCityByCountry(string countryName);

        Task<List<CityModel>> SearchCityByCountryAsync(string countryName);
    }
}
