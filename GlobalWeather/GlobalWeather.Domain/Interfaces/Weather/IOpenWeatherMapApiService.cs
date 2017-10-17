using GlobalWeather.Domain.Models.Weather;

namespace GlobalWeather.Domain.Interfaces.Weather
{
    public interface IOpenWeatherMapApiService
    {
        CurrentWeatherResponse SearchCurrentWeatherByCity(string city, string country);
    }
}
