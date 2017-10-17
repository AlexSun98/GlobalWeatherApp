using System;
using System.Net.Http;
using System.Threading.Tasks;
using GlobalWeather.Infrastructure.Extensions;
using GlobalWeather.Domain.Models.Weather;
using GlobalWeather.Domain.Interfaces.Weather;
using System.Xml;
using System.Xml.Serialization;

namespace GlobalWeather.Infrastructure.IntegratedServices.OpenWeatherMapAPI
{
    public class OpenWeatherMapApiService : IOpenWeatherMapApiService
    {
        private static readonly Uri OpenWeatherMapUrl = new Uri("http://api.openweathermap.org/data/2.5/");

        private static string AppId = "f022196c2869e78172c1ea29d4aebba8";
        private HttpClient HttpClient { get; set; }

        public OpenWeatherMapApiService()
        {
            this.HttpClient = new HttpClient();
        }

        public CurrentWeatherResponse SearchCurrentWeatherByCity(string city, string country)
        {
            var token = string.Format("weather?q={0},{1}&appid={2}&mode=xml", city, country, AppId);
            var requestUri = BuildRequest(token);
            return SendRequest<CurrentWeatherResponse>(requestUri);
        }

        private HttpRequestMessage BuildRequest(string token )
        { 
            var uri = OpenWeatherMapUrl.AddToken(token);
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return request;
        }

        private T SendRequest<T>(HttpRequestMessage request)
        {
            try
            {
                var response = this.HttpClient.SendAsync(request).Result;
                if (!response.IsSuccessStatusCode)
                {
                    this.Log().Error("Failed to fetch etch current weather");
                }

                var responseStream = response.Content.ReadAsStreamAsync();
                var xmlSerializer = new XmlSerializer(typeof(T));
                var xmlReader = XmlReader.Create(responseStream.Result);
                if (xmlSerializer.CanDeserialize(xmlReader))
                {
                    return (T)xmlSerializer.Deserialize(xmlReader);
                }
                else
                    return default(T);
            
            }
            catch (Exception ex)
            {
                this.Log().Error("Error - {0}", ex);
                return default(T);
            }
        }
    }
}
