using Acme.RestaurantHelper.Models;
using Acme.RestaurantHelper.Models.Enums;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Acme.RestaurantHelper.Tests")]

namespace Acme.RestaurantHelper.Services
{
    public class WeatherClient : IWeatherClient
    {
        private readonly AppSettings _appSettings;
        private static HttpClient _httpClient;

        public WeatherClient(IOptions<AppSettings> appSettings, IHttpClientFactory httpClientFactory)
        {
            _appSettings = appSettings.Value;
            _httpClient = httpClientFactory.CreateClient("weatherClient");
        }

        public async Task<IEnumerable<WeatherModel>> GetWeather()
        {
            var results = await _httpClient.GetAsync(WeatherUris.GetWeather(_appSettings.City, _appSettings.Units, _appSettings.AppId));
            var searchResults = JsonConvert.DeserializeObject<SearchResults>(await results.Content.ReadAsStringAsync());

            var timeToUse = searchResults.list.ToList().FirstOrDefault().Date.TimeOfDay;

            var resultsList = new List<WeatherModel>();

            for (int i = 0; i < 5; i++)
            {
                var day = DateTime.Now.AddDays(i).Date;
                var dateToUse = new DateTime(day.Year, day.Month, day.Day, timeToUse.Hours, timeToUse.Minutes, timeToUse.Seconds);

                var weatherModel = searchResults.list.ToList().Where(x => x.Date == dateToUse).FirstOrDefault();
                resultsList.Add(new WeatherModel()
                {
                    Date = weatherModel.Date,
                    Temparature = weatherModel.Temperature.CurrentTemp,
                    ContactMethod = GetContactMethod(weatherModel.Temperature.CurrentTemp, weatherModel.WeatherDetails.FirstOrDefault()?.Main),
                });
            }

            return resultsList;
        }

        internal ContactMethodEnum GetContactMethod(decimal temp, string conditions = null)
        {
            if (temp < 55 || conditions?.ToLower() == "raining")
                return ContactMethodEnum.PhoneCall;
            if (temp >= 55 && temp <= 75)
                return ContactMethodEnum.Email;
            if (temp > 75 && conditions?.ToLower() == "clear")
                return ContactMethodEnum.TextMessage;

            return ContactMethodEnum.Unknown;
        }
    }
}
