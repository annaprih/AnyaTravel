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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        async Task<OrderDTO> IService<OrderDTO, int>.Add(OrderDTO entity)
        {
            Order order = await _orderRepository.Add(_mapper.Map<OrderDTO, Order>(entity));
            return _mapper.Map<Order, OrderDTO>(order);
        }

        async Task<OrderDTO> IService<OrderDTO, int>.Delete(OrderDTO entity)
        {
            Order order = await _orderRepository.Delete(_mapper.Map<OrderDTO, Order>(entity));
            return _mapper.Map<Order, OrderDTO>(order);
        }

        async Task<IEnumerable<OrderDTO>> IService<OrderDTO, int>.Get()
        {
            IEnumerable<Order> orders = await _orderRepository.Get();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }

        async Task<IEnumerable<OrderDTO>> IService<OrderDTO, int>.Get(Func<OrderDTO, bool> predicate)
        {

            Func<Order, bool> order = _mapper.Map<Func<OrderDTO, bool>, Func<Order, bool>>(predicate);
            IEnumerable<Order> orders = await _orderRepository.Get(order);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }

        async Task<OrderDTO> IService<OrderDTO, int>.Get(int id)
        {
            Order order = await _orderRepository.Get(id);
            return _mapper.Map<Order, OrderDTO>(order);
        }

        async Task<OrderDTO> IService<OrderDTO, int>.Update(OrderDTO entity)
        {
            Order order = await _orderRepository.Update(_mapper.Map<OrderDTO, Order>(entity));
            return _mapper.Map<Order, OrderDTO>(order);
        }
    }
}
