using Autofac;
using GlobalWeather.Domain.Interfaces.GeoInformation;
using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Domain.Services;
using GlobalWeather.Infrastructure.GlobalWeatherAPI;
using GlobalWeather.Infrastructure.GlobalWeatherAPIService;
using GlobalWeather.Infrastructure.IntegratedServices.OpenWeatherMapAPI;
using GlobalWeather.Infrastructure.NisoCountryAPI;

namespace GlobalWeather.Infrastructure.DependencyResolution
{
    public class GlobalWeatherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Services
            builder.RegisterType<GlobalWeatherApiService<GlobalWeatherSoap>>().As<IGlobalWeatherApiService<GlobalWeatherSoap>>().InstancePerLifetimeScope();
            builder.RegisterType<WeatherService>().As<IWeatherService>().InstancePerLifetimeScope();
            builder.RegisterType<NisoCountryApiService>().As<INisoCountryApiService>().InstancePerLifetimeScope();
            builder.RegisterType<OpenWeatherMapApiService>().As<IOpenWeatherMapApiService>().InstancePerLifetimeScope();
            
        }
    }
}
