
using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Domain.Models.Weather;
using GlobalWeather.Infrastructure.Extensions;
using GlobalWeather.Infrastructure.GlobalWeatherAPIService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalWeather.Domain.Services
{
    public class WeatherService : IWeatherService
    {
        IGlobalWeatherApiService<GlobalWeatherSoap> _apiService;

        public WeatherService(IGlobalWeatherApiService<GlobalWeatherSoap> apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<CityModel>> SearchCityByCountryAsync(string countryName)
        {
            var cityModel = new List<CityModel>();
            await Task.Run(async () =>
            {
                try
                {
                    var response = await _apiService.UseAsync(client =>
                    {
                        return client.GetCitiesByCountryAsync(countryName);
                    });


                    cityModel = ApiReponseXmlTransformation(response).ParseXML<List<CityModel>>();

                }
                catch (Exception e)
                {
                    this.Log().Error("Error - {0}", e);
                }
            });
            return cityModel;
        }

        public List<CityModel> SearchCityByCountry(string countryName)
        {
            string response = string.Empty;
            var cityModel = new List<CityModel>();

                try
                {
                    _apiService.Use(client =>
                    {
                        response = client.GetCitiesByCountry(countryName);
                    });

                    cityModel = ApiReponseXmlTransformation(response).ParseXML<List<CityModel>>();

                }
                catch (Exception e)
                {
                    this.Log().Error("Error - {0}", e);
                }
           
            return cityModel;
        }


        private string ApiReponseXmlTransformation(string response)
        {
            return response.Replace("Table>", "CityModel>").Replace("NewDataSet>", "ArrayOfCityModel>");
        } 
       
    }
}
