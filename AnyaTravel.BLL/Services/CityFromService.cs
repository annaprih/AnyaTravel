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
    public class CityFromService : ICityFromService
    {
        private readonly ICityFromRepository _cityFromRepository;
        private readonly IMapper _mapper;

        public CityFromService(ICityFromRepository cityFromRepository, IMapper mapper)
        {
            _cityFromRepository = cityFromRepository;
            _mapper = mapper;
        }

        async Task<CityFromDTO> IService<CityFromDTO, int>.Add(CityFromDTO entity)
        {
            CityFrom cityFrom = await _cityFromRepository.Add(_mapper.Map<CityFromDTO, CityFrom>(entity));
            return _mapper.Map<CityFrom, CityFromDTO>(cityFrom);
        }

        async Task<CityFromDTO> IService<CityFromDTO, int>.Delete(CityFromDTO entity)
        {
            CityFrom cityFrom = await _cityFromRepository.Delete(_mapper.Map<CityFromDTO, CityFrom>(entity));
            return _mapper.Map<CityFrom, CityFromDTO>(cityFrom);
        }

        async Task<IEnumerable<CityFromDTO>> IService<CityFromDTO, int>.Get()
        {
            IEnumerable<CityFrom> cities = await _cityFromRepository.Get();
            return _mapper.Map<IEnumerable<CityFrom>, IEnumerable<CityFromDTO>>(cities);
        }

        async Task<IEnumerable<CityFromDTO>> IService<CityFromDTO, int>.Get(Func<CityFromDTO, bool> predicate)
        {

            Func<CityFrom, bool> cityFrom = _mapper.Map<Func<CityFromDTO, bool>, Func<CityFrom, bool>>(predicate);
            IEnumerable<CityFrom> cities = await _cityFromRepository.Get(cityFrom);
            return _mapper.Map<IEnumerable<CityFrom>, IEnumerable<CityFromDTO>>(cities);
        }

        async Task<CityFromDTO> IService<CityFromDTO, int>.Get(int id)
        {
            CityFrom cityFrom = await _cityFromRepository.Get(id);
            return _mapper.Map<CityFrom, CityFromDTO>(cityFrom);
        }

        async Task<CityFromDTO> IService<CityFromDTO, int>.Update(CityFromDTO entity)
        {
            CityFrom cityFrom = await _cityFromRepository.Update(_mapper.Map<CityFromDTO, CityFrom>(entity));
            return _mapper.Map<CityFrom, CityFromDTO>(cityFrom);
        }
    }
}
