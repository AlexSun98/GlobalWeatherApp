using System.Collections.Generic;

namespace GlobalWeather.Domain.Interfaces.GeoInformation
{
    public interface INisoCountryApiService
    {
        List<string> GetAllCountries();
    }
}
