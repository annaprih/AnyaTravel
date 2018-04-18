using AutoMapper;
using DataBase.Repositories;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using _db = DataBase.Models;

namespace Services.Services
{
    public class CityService : ICityService
    {
        private readonly CityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<City> Create(City item)
        {
           _db.City city = await _cityRepository.Create(_mapper.Map<_db.City>(item));
            return _mapper.Map<City>(city);
        }

        public Task<City> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> Read(Func<City, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<City>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<City> ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<City> Update(City item)
        {
            throw new NotImplementedException();
        }
    }
}
