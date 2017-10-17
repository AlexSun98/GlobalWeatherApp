using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalWeather.Infrastructure.IntegratedServices.OpenWeatherMapAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Threading.Tasks;
using GlobalWeather.Infrastructure.DependencyResolution;
using GlobalWeather.Domain;
using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Domain.Models.Weather;

namespace GlobalWeather.Infrastructure.IntegratedServices.OpenWeatherMapAPI.Tests
{
    [TestClass()]
    public class OpenWeatherMapApiServiceTests
    {
        /// <summary>
        /// This method should be refacted by a dependency builder
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            DependencyBootstrapper.EnsureDependenciesRegistered();
        }


        [TestMethod()]
        [TestCategory("Integration Test")]
        [Description("OpenWeatherMap API should return current weather for Beijing")]
        public void ApiService_Should_Return_A_CurrentWeather_For_Beijing()
        {

            using (var scope = CoreServiceLocator.Current.GetIocContainer().BeginLifetimeScope())
            {
                //ARRANGE
                var city = "Beijing";
                var country = "China";
                var service = scope.Resolve<IOpenWeatherMapApiService>();

                //ASSERT
                var weather = new CurrentWeatherResponse();

                weather =  service.SearchCurrentWeatherByCity(city, country);

                //ACT
                Assert.IsNotNull(weather, "OpenWeather API service should return current weather for Beijing.");
                Assert.IsTrue(weather.City.Name.ToLower().Equals("beijing"), "OpenWeather API service should return Beijing's weather.");
            }
        }
    }
}