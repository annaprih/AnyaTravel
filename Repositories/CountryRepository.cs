using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class CountryRepository : Repository<Country, int>
    {
        public CountryRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
