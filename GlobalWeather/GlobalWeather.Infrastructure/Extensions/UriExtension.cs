using System;

namespace GlobalWeather.Infrastructure.Extensions
{
    public static class UriExtension
    {
        public static Uri AddToken(this Uri url, string token)
        {
            url = new Uri(url.OriginalString + "/" + token);
            return url;
        }
    }
}
