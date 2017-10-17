using GlobalWeather.Domain.Interfaces.Weather;
using GlobalWeather.Infrastructure.Extensions;
using GlobalWeather.Infrastructure.GlobalWeatherAPIService;
using System;
using System.ServiceModel;

namespace GlobalWeather.Infrastructure.GlobalWeatherAPI
{
    public class GlobalWeatherApiService<T> : IGlobalWeatherApiService<T>
    {
      
        public void Use(Action<T> action)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>("GlobalWeatherSoap");
            T client = factory.CreateChannel();

            bool success = false;

            try
            {
                action(client);
                ((IClientChannel)client).Close();
                factory.Close();
                success = true;
            }
            catch (CommunicationException e)
            {
                this.Log().Error("Communication Error - {0}", e);
            }
            catch (TimeoutException e)
            {
                this.Log().Error("Time Out Error - {0}", e);
            }
            catch (Exception e)
            {
                this.Log().Error("Error - {0}", e);
            }
            finally
            {
                if (!success)
                {
                    // abort the channel if it didn't close sucessfully
                    ((IClientChannel)client).Abort();
                    factory.Abort();
                }
            }
        }

        public U UseAsync<U>(Func<T, U> action)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>("GlobalWeatherSoap");
            T client = factory.CreateChannel();

            bool success = false;

            try
            {
                var result = action(client);
                ((IClientChannel)client).Close();
                factory.Close();
                success = true;
                return result;
            }
            catch (CommunicationException e)
            {
                this.Log().Error("Communication Error - {0}", e);
                return default(U);
            }
            catch (TimeoutException e)
            {
                this.Log().Error("Time Out Error - {0}", e);
                return default(U);
            }
            catch (Exception e)
            {
                this.Log().Error("Error - {0}", e);
                return default(U);
            }
            finally
            {
                if (!success)
                {
                    // abort the channel if it didn't close sucessfully
                    ((IClientChannel)client).Abort();
                    factory.Abort();
                }
            }
        }

        private GlobalWeatherSoapClient ApiSoapCustomClientFactory(String endpoint)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);

            binding.MaxBufferSize = 5242880;
            binding.MaxBufferPoolSize = 524288;
            binding.MaxReceivedMessageSize = 5242880;
            binding.ReaderQuotas.MaxArrayLength = 16384;
            binding.ReaderQuotas.MaxDepth = 128;
            binding.ReaderQuotas.MaxStringContentLength = 5242880;
            binding.ReaderQuotas.MaxArrayLength = 16384;
            binding.ReaderQuotas.MaxBytesPerRead = 4096;
            binding.ReaderQuotas.MaxNameTableCharCount = 16384;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
            TimeSpan s = new TimeSpan(TimeSpan.TicksPerMinute * 2);
            binding.SendTimeout = s;

            var address = new EndpointAddress(endpoint);
            return new GlobalWeatherSoapClient(binding, address);
        }

        private GlobalWeatherSoapClient ApiSoapClientFactory()
        {
            return new GlobalWeatherSoapClient("GlobalWeatherSoap");
        }
    }
}
