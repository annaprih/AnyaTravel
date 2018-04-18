using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class ReisRepository : Repository<Reis, int>
    {
        public ReisRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
