using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Acme.RestaurantHelper.Models
{
    public class SearchResults
    {
        public string cod { get; set; }
        public int message { get; set; }
        public IEnumerable<ListResults> list { get; set; }
    }

    public class ListResults
    {
        [JsonProperty("dt")]
        public long Ticks { get; set; }
        public DateTime Date
        {
            get
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(Ticks).ToLocalTime();
                return dtDateTime;
            }
        }

        [JsonProperty("main")]
        public TemperatureModel Temperature { get; set; }
        [JsonProperty("weather")]
        public IEnumerable<WeatherDetailsModel> WeatherDetails { get; set; }
    }

    public class TemperatureModel
    {
        [JsonProperty("temp")]
        public decimal CurrentTemp { get; set; }
    }

    public class WeatherDetailsModel
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
