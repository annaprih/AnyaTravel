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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IMapper _mapper;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository, IMapper mapper)
        {
            _orderStatusRepository = orderStatusRepository;
            _mapper = mapper;
        }

        async Task<OrderStatusDTO> IService<OrderStatusDTO, int>.Add(OrderStatusDTO entity)
        {
            OrderStatus orderStatus = await _orderStatusRepository.Add(_mapper.Map<OrderStatusDTO, OrderStatus>(entity));
            return _mapper.Map<OrderStatus, OrderStatusDTO>(orderStatus);
        }

        async Task<OrderStatusDTO> IService<OrderStatusDTO, int>.Delete(OrderStatusDTO entity)
        {
            OrderStatus orderStatus = await _orderStatusRepository.Delete(_mapper.Map<OrderStatusDTO, OrderStatus>(entity));
            return _mapper.Map<OrderStatus, OrderStatusDTO>(orderStatus);
        }

        async Task<IEnumerable<OrderStatusDTO>> IService<OrderStatusDTO, int>.Get()
        {
            IEnumerable<OrderStatus> orders = await _orderStatusRepository.Get();
            return _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusDTO>>(orders);
        }

        async Task<IEnumerable<OrderStatusDTO>> IService<OrderStatusDTO, int>.Get(Func<OrderStatusDTO, bool> predicate)
        {

            Func<OrderStatus, bool> orderStatus = _mapper.Map<Func<OrderStatusDTO, bool>, Func<OrderStatus, bool>>(predicate);
            IEnumerable<OrderStatus> orders = await _orderStatusRepository.Get(orderStatus);
            return _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusDTO>>(orders);
        }

        async Task<OrderStatusDTO> IService<OrderStatusDTO, int>.Get(int id)
        {
            OrderStatus orderStatus = await _orderStatusRepository.Get(id);
            return _mapper.Map<OrderStatus, OrderStatusDTO>(orderStatus);
        }

        async Task<OrderStatusDTO> IService<OrderStatusDTO, int>.Update(OrderStatusDTO entity)
        {
            OrderStatus orderStatus = await _orderStatusRepository.Update(_mapper.Map<OrderStatusDTO, OrderStatus>(entity));
            return _mapper.Map<OrderStatus, OrderStatusDTO>(orderStatus);
        }
    }
}
