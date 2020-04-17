using Acme.RestaurantHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.RestaurantHelper.Services
{
    public interface IWeatherClient
    {
        Task<IEnumerable<WeatherModel>> GetWeather();
    }
}
