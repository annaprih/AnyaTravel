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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        async Task<CountryDTO> IService<CountryDTO, int>.Add(CountryDTO entity)
        {
            Country country = await _countryRepository.Add(_mapper.Map<CountryDTO, Country>(entity));
            return _mapper.Map<Country, CountryDTO>(country);
        }

        async Task<CountryDTO> IService<CountryDTO, int>.Delete(CountryDTO entity)
        {
            Country country = await _countryRepository.Delete(_mapper.Map<CountryDTO, Country>(entity));
            return _mapper.Map<Country, CountryDTO>(country);
        }

        async Task<IEnumerable<CountryDTO>> IService<CountryDTO, int>.Get()
        {
            IEnumerable<Country> countries = await _countryRepository.Get();
            return _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(countries);
        }

        async Task<IEnumerable<CountryDTO>> IService<CountryDTO, int>.Get(Func<CountryDTO, bool> predicate)
        {

            Func<Country, bool> country = _mapper.Map<Func<CountryDTO, bool>, Func<Country, bool>>(predicate);
            IEnumerable<Country> countries = await _countryRepository.Get(country);
            return _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(countries);
        }

        async Task<CountryDTO> IService<CountryDTO, int>.Get(int id)
        {
            Country country = await _countryRepository.Get(id);
            return _mapper.Map<Country, CountryDTO>(country);
        }

        async Task<CountryDTO> IService<CountryDTO, int>.Update(CountryDTO entity)
        {
            Country country = await _countryRepository.Update(_mapper.Map<CountryDTO, Country>(entity));
            return _mapper.Map<Country, CountryDTO>(country);
        }
    }
}
