using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class CustomerRepository : Repository<Customer, int>
    {
        public CustomerRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
