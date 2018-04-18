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
    public class TourTypeService : ITourTypeService
    {
        private readonly ITourTypeRepository _tourTypeRepository;
        private readonly IMapper _mapper;

        public TourTypeService(ITourTypeRepository tourTypeRepository, IMapper mapper)
        {
            _tourTypeRepository = tourTypeRepository;
            _mapper = mapper;
        }

        async Task<TourTypeDTO> IService<TourTypeDTO, int>.Add(TourTypeDTO entity)
        {
            TourType tourType = await _tourTypeRepository.Add(_mapper.Map<TourTypeDTO, TourType>(entity));
            return _mapper.Map<TourType, TourTypeDTO>(tourType);
        }

        async Task<TourTypeDTO> IService<TourTypeDTO, int>.Delete(TourTypeDTO entity)
        {
            TourType tourType = await _tourTypeRepository.Delete(_mapper.Map<TourTypeDTO, TourType>(entity));
            return _mapper.Map<TourType, TourTypeDTO>(tourType);
        }

        async Task<IEnumerable<TourTypeDTO>> IService<TourTypeDTO, int>.Get()
        {
            IEnumerable<TourType> tours = await _tourTypeRepository.Get();
            return _mapper.Map<IEnumerable<TourType>, IEnumerable<TourTypeDTO>>(tours);
        }

        async Task<IEnumerable<TourTypeDTO>> IService<TourTypeDTO, int>.Get(Func<TourTypeDTO, bool> predicate)
        {

            Func<TourType, bool> tourType = _mapper.Map<Func<TourTypeDTO, bool>, Func<TourType, bool>>(predicate);
            IEnumerable<TourType> tours = await _tourTypeRepository.Get(tourType);
            return _mapper.Map<IEnumerable<TourType>, IEnumerable<TourTypeDTO>>(tours);
        }

        async Task<TourTypeDTO> IService<TourTypeDTO, int>.Get(int id)
        {
            TourType tourType = await _tourTypeRepository.Get(id);
            return _mapper.Map<TourType, TourTypeDTO>(tourType);
        }

        async Task<TourTypeDTO> IService<TourTypeDTO, int>.Update(TourTypeDTO entity)
        {
            TourType tourType = await _tourTypeRepository.Update(_mapper.Map<TourTypeDTO, TourType>(entity));
            return _mapper.Map<TourType, TourTypeDTO>(tourType);
        }
    }
}
