using AutoMapper;
using AnyaTravel.BLL.Data;
using AnyaTravel.API.ViewModels;

namespace AnyaTravel.API.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SignIn, UserDTO>().ReverseMap();
            CreateMap<UserDTO, SignUp>().ReverseMap();
            CreateMap<TourDTO, TourView>().ReverseMap();
            CreateMap<CityDTO, CityView>().ReverseMap();
            CreateMap<HotelDTO, HotelView>().ReverseMap();
        }
    }
}
