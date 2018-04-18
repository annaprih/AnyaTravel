using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class TourRepository : Repository<Tour, int>
    {
        public TourRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
