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
    public class FoodTypeService : IFoodTypeService
    {
        private readonly IFoodTypeRepository _foodTypeRepository;
        private readonly IMapper _mapper;

        public FoodTypeService(IFoodTypeRepository foodTypeRepository, IMapper mapper)
        {
            _foodTypeRepository = foodTypeRepository;
            _mapper = mapper;
        }

        async Task<FoodTypeDTO> IService<FoodTypeDTO, int>.Add(FoodTypeDTO entity)
        {
            FoodType foodType = await _foodTypeRepository.Add(_mapper.Map<FoodTypeDTO, FoodType>(entity));
            return _mapper.Map<FoodType, FoodTypeDTO>(foodType);
        }

        async Task<FoodTypeDTO> IService<FoodTypeDTO, int>.Delete(FoodTypeDTO entity)
        {
            FoodType foodType = await _foodTypeRepository.Delete(_mapper.Map<FoodTypeDTO, FoodType>(entity));
            return _mapper.Map<FoodType, FoodTypeDTO>(foodType);
        }

        async Task<IEnumerable<FoodTypeDTO>> IService<FoodTypeDTO, int>.Get()
        {
            IEnumerable<FoodType> foodTypes = await _foodTypeRepository.Get();
            return _mapper.Map<IEnumerable<FoodType>, IEnumerable<FoodTypeDTO>>(foodTypes);
        }

        async Task<IEnumerable<FoodTypeDTO>> IService<FoodTypeDTO, int>.Get(Func<FoodTypeDTO, bool> predicate)
        {

            Func<FoodType, bool> foodType = _mapper.Map<Func<FoodTypeDTO, bool>, Func<FoodType, bool>>(predicate);
            IEnumerable<FoodType> foodTypes = await _foodTypeRepository.Get(foodType);
            return _mapper.Map<IEnumerable<FoodType>, IEnumerable<FoodTypeDTO>>(foodTypes);
        }

        async Task<FoodTypeDTO> IService<FoodTypeDTO, int>.Get(int id)
        {
            FoodType foodType = await _foodTypeRepository.Get(id);
            return _mapper.Map<FoodType, FoodTypeDTO>(foodType);
        }

        async Task<FoodTypeDTO> IService<FoodTypeDTO, int>.Update(FoodTypeDTO entity)
        {
            FoodType foodType = await _foodTypeRepository.Update(_mapper.Map<FoodTypeDTO, FoodType>(entity));
            return _mapper.Map<FoodType, FoodTypeDTO>(foodType);
        }
    }
}
