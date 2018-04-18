using DataBase.Context;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Repositories
{
    public class TransportTypeRepository : Repository<TransportType, int>
    {
        public TransportTypeRepository(ContextDB contextDB) : base(contextDB) { }

    }
}
