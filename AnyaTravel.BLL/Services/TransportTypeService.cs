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
    public class TransportTypeService : ITransportTypeService
    {
        private readonly ITransportTypeRepository _transportTypeRepository;
        private readonly IMapper _mapper;

        public TransportTypeService(ITransportTypeRepository transportTypeRepository, IMapper mapper)
        {
            _transportTypeRepository = transportTypeRepository;
            _mapper = mapper;
        }

        async Task<TransportTypeDTO> IService<TransportTypeDTO, int>.Add(TransportTypeDTO entity)
        {
            TransportType transportType = await _transportTypeRepository.Add(_mapper.Map<TransportTypeDTO, TransportType>(entity));
            return _mapper.Map<TransportType, TransportTypeDTO>(transportType);
        }

        async Task<TransportTypeDTO> IService<TransportTypeDTO, int>.Delete(TransportTypeDTO entity)
        {
            TransportType transportType = await _transportTypeRepository.Delete(_mapper.Map<TransportTypeDTO, TransportType>(entity));
            return _mapper.Map<TransportType, TransportTypeDTO>(transportType);
        }

        async Task<IEnumerable<TransportTypeDTO>> IService<TransportTypeDTO, int>.Get()
        {
            IEnumerable<TransportType> transports = await _transportTypeRepository.Get();
            return _mapper.Map<IEnumerable<TransportType>, IEnumerable<TransportTypeDTO>>(transports);
        }

        async Task<IEnumerable<TransportTypeDTO>> IService<TransportTypeDTO, int>.Get(Func<TransportTypeDTO, bool> predicate)
        {

            Func<TransportType, bool> transportType = _mapper.Map<Func<TransportTypeDTO, bool>, Func<TransportType, bool>>(predicate);
            IEnumerable<TransportType> transports = await _transportTypeRepository.Get(transportType);
            return _mapper.Map<IEnumerable<TransportType>, IEnumerable<TransportTypeDTO>>(transports);
        }

        async Task<TransportTypeDTO> IService<TransportTypeDTO, int>.Get(int id)
        {
            TransportType transportType = await _transportTypeRepository.Get(id);
            return _mapper.Map<TransportType, TransportTypeDTO>(transportType);
        }

        async Task<TransportTypeDTO> IService<TransportTypeDTO, int>.Update(TransportTypeDTO entity)
        {
            TransportType transportType = await _transportTypeRepository.Update(_mapper.Map<TransportTypeDTO, TransportType>(entity));
            return _mapper.Map<TransportType, TransportTypeDTO>(transportType);
        }
    }
}
