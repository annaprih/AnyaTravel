using AutoMapper;
using AnyaTravel.BLL.Data;
using AnyaTravel.API.ViewModels;
using AnyaTravel.DAL.Models;
using System;

namespace AnyaTravel.API.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SignIn, UserDTO>().PreserveReferences().ReverseMap();
            CreateMap<UserDTO, SignUp>().PreserveReferences().ReverseMap();
            CreateMap<Tour, TourDTO>().PreserveReferences().ReverseMap();
            CreateMap<FoodType, FoodTypeDTO>().PreserveReferences().ReverseMap();
            CreateMap<TransportType, TransportTypeDTO>().PreserveReferences().ReverseMap();
            CreateMap<PlacementType, PlacementTypeDTO>().PreserveReferences().ReverseMap();
            CreateMap<CityFrom, CityFromDTO>().PreserveReferences().ReverseMap();
            CreateMap<Country, CountryDTO>().PreserveReferences().ReverseMap();
            CreateMap<City, CityDTO>().PreserveReferences().ReverseMap();
            CreateMap<Hotel, HotelDTO>().PreserveReferences().ReverseMap();
            CreateMap<Order, OrderDTO>().PreserveReferences().ReverseMap();
            CreateMap<Func<Order,bool>, Func<OrderDTO, bool>>().PreserveReferences().ReverseMap();
            CreateMap<CurrentUser, UserDTO>().PreserveReferences().ReverseMap();
            CreateMap<User, UserDTO>().PreserveReferences().IgnoreAllPropertiesWithAnInaccessibleSetter().IgnoreAllSourcePropertiesWithAnInaccessibleSetter().ReverseMap();


            CreateMap<TourDTO, TourView>().ReverseMap();
            CreateMap<CityDTO, CityView>().ReverseMap();
            CreateMap<HotelDTO, HotelView>().ReverseMap();
        }
    }
}
