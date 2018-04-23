using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AnyaTravel.BLL.Data;
using AnyaTravel.BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnyaTravel.API.Controllers
{
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IUserService userService,
            ITourService tourService, IMapper mapper)
        {
            _orderService = orderService;
            _userService = userService;
            _tourService = tourService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/order")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<OrderDTO> orders = await _orderService.Get();
            return Ok(orders);
        }

        [HttpGet]
        [Route("api/order/currentuser")]
        public async Task<IActionResult> GetByUser()
        {
            IEnumerable<OrderDTO> orders = await _orderService.Get(order => order.User.UserName == User.Identity.Name);
            return Ok(orders);
        }

        [HttpPost]
        [Route("api/order/{tourId}")]
        public async Task<IActionResult> Add([Required]int tourId)
        {
            if (ModelState.IsValid)
            {
                OrderDTO order = await AddOrderProp(tourId);
                return Ok(order);
            }
            return BadRequest(ModelState);
        }

        private async Task<OrderDTO> AddOrderProp(int tourId)
        {

            OrderDTO order = new OrderDTO();
            CurrentUser user = await _userService.GetUser(User.Identity.Name);
            order.OrderStatus = new OrderStatusDTO { Status = 0 };
            order.User = _mapper.Map<CurrentUser, UserDTO>(user);
            order.Date = DateTime.Now;
            order.Tour = await _tourService.Get(tourId);
            order.Price = order.Tour.Price;
            if (order.User.Orders.Count >= 2)
            {
                order.Price = (int)(order.Tour.Price * 0.95);
            }
            order = await _orderService.Add(order);
            return order;
        }

        [HttpPut]
        [Route("api/order/{id}")]
        public async Task<IActionResult> Update([Required]int id)
        {
            if (ModelState.IsValid)
            {
                OrderDTO order = await _orderService.Get(id);
                if (order != null)
                {
                    order.OrderStatus = new OrderStatusDTO { Status = 1 };
                    order = await _orderService.Update(order);
                    return Ok(order);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }


        [HttpDelete]
        [Route("api/order/{id}")]
        public async Task<IActionResult> Delete([Required]int id)
        {
            if (ModelState.IsValid)
            {
                OrderDTO order = await _orderService.Get(id);
                if (order != null)
                {
                    order = await _orderService.Delete(order);
                    return Ok(order);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

    }
}