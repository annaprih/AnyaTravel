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
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        async Task<TourDTO> IService<TourDTO, int>.Add(TourDTO entity)
        {
            Tour tour = await _tourRepository.Add(_mapper.Map<TourDTO, Tour>(entity));
            return _mapper.Map<Tour, TourDTO>(tour);
        }

        async Task<TourDTO> IService<TourDTO, int>.Delete(TourDTO entity)
        {
            Tour tour = await _tourRepository.Delete(_mapper.Map<TourDTO, Tour>(entity));
            return _mapper.Map<Tour, TourDTO>(tour);
        }

        async Task<IEnumerable<TourDTO>> IService<TourDTO, int>.Get()
        {
            IEnumerable<Tour> tours = await _tourRepository.Get();
            return _mapper.Map<IEnumerable<Tour>, IEnumerable<TourDTO>>(tours);
        }

        async Task<IEnumerable<TourDTO>> IService<TourDTO, int>.Get(Func<TourDTO, bool> predicate)
        {
            Func<Tour, bool> tour = _mapper.Map<Func<TourDTO, bool>, Func<Tour, bool>>(predicate);
            IEnumerable<Tour> tours = await _tourRepository.Get(tour);
            return _mapper.Map<IEnumerable<Tour>, IEnumerable<TourDTO>>(tours);
        }

        async Task<TourDTO> IService<TourDTO, int>.Get(int id)
        {
            Tour tour = await _tourRepository.Get(id);
            return _mapper.Map<Tour, TourDTO>(tour);
        }

        async Task<TourDTO> IService<TourDTO, int>.Update(TourDTO entity)
        {
            Tour tour = await _tourRepository.Update(_mapper.Map<TourDTO, Tour>(entity));
            return _mapper.Map<Tour, TourDTO>(tour);
        }
    }
}
