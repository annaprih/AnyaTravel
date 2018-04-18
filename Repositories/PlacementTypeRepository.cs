using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class PlacementTypeRepository : Repository<PlacementType, int>
    {
        public PlacementTypeRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
