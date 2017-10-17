
using Serilog;

namespace GlobalWeather.Infrastructure.Logging
{
    public class LoggerAdapter
    {
        private const string _loggerName = "Serilog";
        private static ILogger _logger;

        internal LoggerAdapter(ILogger log)
        {
            _logger = log;
        }
    }
}
