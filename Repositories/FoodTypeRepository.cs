using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class FoodTypeRepository : Repository<FoodType, int>
    {
        public FoodTypeRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
