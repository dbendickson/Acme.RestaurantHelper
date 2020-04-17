using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.RestaurantHelper.Services;
using Acme.RestaurantHelper.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Acme.RestaurantHelper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherClient _weatherClient;
        private readonly IMapper _mapper;

        public WeatherController(IWeatherClient weatherClient, IMapper mapper)
        {
            _weatherClient = weatherClient;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherViewModel>> Get()
        {
            var results = await _weatherClient.GetWeather();

            return _mapper.Map<List<WeatherViewModel>>(results).ToArray();
        }
    }
}
