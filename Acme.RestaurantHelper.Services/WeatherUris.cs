using System;

namespace Acme.RestaurantHelper.Services
{
    public class WeatherUris
    {
        public static Uri GetWeather(string location, string units, string appId)
        {
            return new Uri($"data/2.5/forecast/?q={location}&units={units}&APPID={appId}", UriKind.Relative);
        }
    }
}
