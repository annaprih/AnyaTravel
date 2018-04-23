using AnyaTravel.BLL.Data;
using AnyaTravel.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyaTravel.BLL.Interfaces
{
    public interface IOrderService: IService<OrderDTO, int>
    {
        Task<IEnumerable<OrderDTO>> Get(Func<Order, bool> predicate);
    }
}
