using Serilog;
using System;

namespace GlobalWeather.Infrastructure.Logging
{
    public interface ILogManager
    {
        ILogger GetLogger(Type type);
        ILogger GetLogger<T>();
    }
}
