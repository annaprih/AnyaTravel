using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Interfaces;
using AnyaTravel.DAL.Interfaces;
using AnyaTravel.DAL.Models;
using AutoMapper;

namespace Services.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        async Task<HotelDTO> IService<HotelDTO, int>.Add(HotelDTO entity)
        {
            Hotel hotel = await _hotelRepository.Add(_mapper.Map<HotelDTO, Hotel>(entity));
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }

        async Task<HotelDTO> IService<HotelDTO, int>.Delete(HotelDTO entity)
        {
            Hotel hotel = await _hotelRepository.Delete(_mapper.Map<HotelDTO, Hotel>(entity));
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }

        async Task<IEnumerable<HotelDTO>> IService<HotelDTO, int>.Get()
        {
            IEnumerable<Hotel> hotels = await _hotelRepository.Get();
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        async Task<IEnumerable<HotelDTO>> IService<HotelDTO, int>.Get(Func<HotelDTO, bool> predicate)
        {

            Func<Hotel, bool> hotel = _mapper.Map<Func<HotelDTO, bool>, Func<Hotel, bool>>(predicate);
            IEnumerable<Hotel> hotels = await _hotelRepository.Get(hotel);
            return _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotels);
        }

        async Task<HotelDTO> IService<HotelDTO, int>.Get(int id)
        {
            Hotel hotel = await _hotelRepository.Get(id);
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }

        async Task<HotelDTO> IService<HotelDTO, int>.Update(HotelDTO entity)
        {
            Hotel hotel = await _hotelRepository.Update(_mapper.Map<HotelDTO, Hotel>(entity));
            return _mapper.Map<Hotel, HotelDTO>(hotel);
        }
    }
}
