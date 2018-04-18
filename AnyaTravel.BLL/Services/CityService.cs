using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Interfaces;
using AnyaTravel.DAL.Interfaces;
using AnyaTravel.DAL.Models;
using AutoMapper;

namespace AnyaTravel.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        async Task<CityDTO> IService<CityDTO, int>.Add(CityDTO entity)
        {
            City city = await _cityRepository.Add(_mapper.Map<CityDTO, City>(entity));
            return _mapper.Map<City, CityDTO>(city);
        }

        async Task<CityDTO> IService<CityDTO, int>.Delete(CityDTO entity)
        {
            City city = await _cityRepository.Delete(_mapper.Map<CityDTO, City>(entity));
            return _mapper.Map<City, CityDTO>(city);
        }

        async Task<IEnumerable<CityDTO>> IService<CityDTO, int>.Get()
        {
            IEnumerable<City> cities = await _cityRepository.Get();
            return _mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cities);
        }

        async Task<IEnumerable<CityDTO>> IService<CityDTO, int>.Get(Func<CityDTO, bool> predicate)
        {

            Func<City, bool> city = _mapper.Map<Func<CityDTO, bool>, Func<City, bool>>(predicate);
            IEnumerable<City> cities = await _cityRepository.Get(city);
            return _mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cities);
        }

        async Task<CityDTO> IService<CityDTO, int>.Get(int id)
        {
            City city = await _cityRepository.Get(id);
            return _mapper.Map<City, CityDTO>(city);
        }

        async Task<CityDTO> IService<CityDTO, int>.Update(CityDTO entity)
        {
            City city = await _cityRepository.Update(_mapper.Map<CityDTO, City>(entity));
            return _mapper.Map<City, CityDTO>(city);
        }
    }
}
