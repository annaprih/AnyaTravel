using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class TourTypeRepository : Repository<TourType, int>
    {
        public TourTypeRepository(ContextDB contextDB) : base(contextDB) { }
    }
}
