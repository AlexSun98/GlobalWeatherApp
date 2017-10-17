using Autofac;
using GlobalWeather.Domain;
using GlobalWeather.Infrastructure.DependencyResolution.AutofacConfiguration;

namespace GlobalWeather.Infrastructure.DependencyResolution
{
    public class DependencyBootstrapper
    {
        private static bool _dependenciesRegistered;
        private static readonly object sync = new object();

        internal void RegisterAllDependenciesOnStartup()
        {
            ConfigureAutofac();
        }

        /// <summary>
        /// Perform registrations and build the container - http://docs.autofac.org/en/latest/integration/csl.html
        /// </summary>
        private void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new GlobalWeatherModule());
            var container = builder.Build();

            CoreServiceLocator.SetServiceLocator(() => new AutofacServiceLocator(container));
        }


        public static void EnsureDependenciesRegistered()
        {
            if (!_dependenciesRegistered)
            {
                lock (sync)
                {
                    if (!_dependenciesRegistered)
                    {
                        new DependencyBootstrapper().RegisterAllDependenciesOnStartup();
                        _dependenciesRegistered = true;
                    }
                }
            }
        }
    }
}

