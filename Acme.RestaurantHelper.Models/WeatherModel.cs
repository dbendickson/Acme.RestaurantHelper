using Acme.RestaurantHelper.Models.Enums;
using System;

namespace Acme.RestaurantHelper.Models
{
    public class WeatherModel
    {
        public DateTime Date { get; set; }
        public decimal Temparature { get; set; }
        public ContactMethodEnum ContactMethod { get; set; }
    }
}
