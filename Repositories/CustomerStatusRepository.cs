using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class CustomerStatusRepository : Repository<Customer, int>
    {
        public CustomerStatusRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
