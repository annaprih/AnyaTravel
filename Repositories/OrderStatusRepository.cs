using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class OrderStatusRepository : Repository<OrderStatus, int>
    {
        public OrderStatusRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
