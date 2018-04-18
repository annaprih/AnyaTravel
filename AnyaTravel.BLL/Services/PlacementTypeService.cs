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
    public class PlacementTypeService : IPlacementTypeService
    {
        private readonly IPlacementTypeRepository _placementTypeRepository;
        private readonly IMapper _mapper;

        public PlacementTypeService(IPlacementTypeRepository placementTypeRepository, IMapper mapper)
        {
            _placementTypeRepository = placementTypeRepository;
            _mapper = mapper;
        }

        async Task<PlacementTypeDTO> IService<PlacementTypeDTO, int>.Add(PlacementTypeDTO entity)
        {
            PlacementType placementType = await _placementTypeRepository.Add(_mapper.Map<PlacementTypeDTO, PlacementType>(entity));
            return _mapper.Map<PlacementType, PlacementTypeDTO>(placementType);
        }

        async Task<PlacementTypeDTO> IService<PlacementTypeDTO, int>.Delete(PlacementTypeDTO entity)
        {
            PlacementType placementType = await _placementTypeRepository.Delete(_mapper.Map<PlacementTypeDTO, PlacementType>(entity));
            return _mapper.Map<PlacementType, PlacementTypeDTO>(placementType);
        }

        async Task<IEnumerable<PlacementTypeDTO>> IService<PlacementTypeDTO, int>.Get()
        {
            IEnumerable<PlacementType> placements = await _placementTypeRepository.Get();
            return _mapper.Map<IEnumerable<PlacementType>, IEnumerable<PlacementTypeDTO>>(placements);
        }

        async Task<IEnumerable<PlacementTypeDTO>> IService<PlacementTypeDTO, int>.Get(Func<PlacementTypeDTO, bool> predicate)
        {

            Func<PlacementType, bool> placementType = _mapper.Map<Func<PlacementTypeDTO, bool>, Func<PlacementType, bool>>(predicate);
            IEnumerable<PlacementType> placements = await _placementTypeRepository.Get(placementType);
            return _mapper.Map<IEnumerable<PlacementType>, IEnumerable<PlacementTypeDTO>>(placements);
        }

        async Task<PlacementTypeDTO> IService<PlacementTypeDTO, int>.Get(int id)
        {
            PlacementType placementType = await _placementTypeRepository.Get(id);
            return _mapper.Map<PlacementType, PlacementTypeDTO>(placementType);
        }

        async Task<PlacementTypeDTO> IService<PlacementTypeDTO, int>.Update(PlacementTypeDTO entity)
        {
            PlacementType placementType = await _placementTypeRepository.Update(_mapper.Map<PlacementTypeDTO, PlacementType>(entity));
            return _mapper.Map<PlacementType, PlacementTypeDTO>(placementType);
        }
    }
}
