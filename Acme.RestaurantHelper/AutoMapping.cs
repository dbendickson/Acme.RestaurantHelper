using Acme.RestaurantHelper.Models;
using Acme.RestaurantHelper.Models.Enums;
using Acme.RestaurantHelper.Services;
using Acme.RestaurantHelper.ViewModels;
using AutoMapper;

namespace Acme.RestaurantHelper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<WeatherModel, WeatherViewModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("M/d/yyyy")))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Date.ToString("h:mm tt")))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temparature.ToString()));
            CreateMap<ContactMethodEnum, string>().ConvertUsing(src => EnumHelper.GetEnumDescription(src));
        }
    }
}
