using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class CityRepository : Repository<City, int>
    {
        public CityRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
