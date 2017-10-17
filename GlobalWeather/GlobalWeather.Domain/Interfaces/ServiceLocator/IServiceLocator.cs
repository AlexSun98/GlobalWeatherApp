using System;

namespace GlobalWeather.Domain.Interfaces.ServiceLocator
{
    public interface IServiceLocator : IServiceProvider
    {
        T GetInstance<T>();
        T GetInstance<T>(string name);
        object GetInstance(Type type);
        Autofac.IContainer GetIocContainer();
    }
}
