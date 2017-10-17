using Serilog;
using System;

namespace GlobalWeather.Infrastructure.Logging
{
    public class LogManager : ILogManager
    {
        static readonly ILogManager _logManager;

        static LogManager()
        {
            _logManager = new LogManager();
        }

        /// <summary>
        /// Factory method returns Serilog 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ILogger GetLogger(Type type)
        {
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.LiterateConsole()
                    .WriteTo.RollingFile("log-{Date}.txt")
                    .CreateLogger();

            return Log.Logger;
        }

        public ILogger GetLogger<T>()
        {
            return _logManager.GetLogger(typeof(T));
        }
    }
}
