
using GlobalWeather.Infrastructure.Logging;
using Serilog;

namespace GlobalWeather.Infrastructure.Extensions
{

    public static class LoggingExtension
    {
        /// <summary>
        /// You can call any class .Log. It's very handy :)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thing"></param>
        /// <returns></returns>
        public static ILogger Log<T>(this T thing)
        {
            var logManager = new LogManager();
            var log = logManager.GetLogger<T>();
            return log;
        }
    }
}
