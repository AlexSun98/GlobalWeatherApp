using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalWeather.Infrastructure.DependencyResolution;
using Autofac;
using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Domain.Models.Weather;

namespace GlobalWeather.Domain.Services.Tests
{
    [TestClass()]
    public class WeatherServiceTests
    {
        /// <summary>
        /// Should create a dependency builder and intercepter for tests
        /// </summary>
        /// <param name="testContext"></param>
        [ClassInitialize()]
        public static void Initialize(TestContext testContext)
        {
            DependencyBootstrapper.EnsureDependenciesRegistered();
        }

        [TestMethod()]
        [TestCategory("Integration Test")]
        [Description("Global weather service should return cities for Australia")]
        public void ApiService_Should_Return_A_Cities_For_Australia()
        {
          
            using (var scope = CoreServiceLocator.Current.GetIocContainer().BeginLifetimeScope())
            {
                //ARRANGE

                var service = scope.Resolve<IWeatherService>();

                //ASSERT
                var cityList = new List<CityModel>();

                Task.Run(async () => { cityList = await service.SearchCityByCountryAsync("AU"); }).Wait();

                //ACT
                Assert.IsNotNull(cityList, "Global weather service should return cities for Australia.");
                Assert.IsTrue(cityList.Any(), "Global weather service should return cities for Australia.");
            }
        }
    }
}