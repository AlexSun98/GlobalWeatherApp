using System.Web.Http;
using GlobalWeather.Infrastructure.DependencyResolution;

namespace GlobalWeather.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            DependencyBootstrapper.EnsureDependenciesRegistered();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               "ActionApi",
               "api/{controller}/{action}/{id}",
               new { id = RouteParameter.Optional }
           );
        }
    }
}
