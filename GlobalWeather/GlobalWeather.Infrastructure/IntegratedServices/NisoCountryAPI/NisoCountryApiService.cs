using GlobalWeather.Domain.Interfaces.GeoInformation;
using System.Collections.Generic;
using NISOCountries.Wikipedia.CSQ;
using System.Linq;

namespace GlobalWeather.Infrastructure.NisoCountryAPI
{
    public class NisoCountryApiService : INisoCountryApiService
    {
        public List<string> GetAllCountries()
        {
            var countries = new WikipediaISOCountryReader().GetDefault();
            return countries.Select(x => x.CountryName).ToList();
        }
    }
}
