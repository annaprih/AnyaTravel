using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class HotelRepository : Repository<Hotel, int>
    {
        public HotelRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
