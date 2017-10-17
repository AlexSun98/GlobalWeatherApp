using System;

namespace GlobalWeather.Domain.Interfaces.Weather
{
    public interface IGlobalWeatherApiService<T>
    {
        void Use(Action<T> action);

        U UseAsync<U>(Func<T, U> action);
    }
}
