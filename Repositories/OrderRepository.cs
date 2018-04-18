using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class OrderRepository : Repository<Order, int>
    {
        public OrderRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
