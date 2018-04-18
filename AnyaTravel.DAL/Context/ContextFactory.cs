using AnyaTravel.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnyaTravel.DAL.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TravelCompany;Integrated Security=True;Connection Timeout=300");

            return new ContextDB(optionsBuilder.Options);
        }
    }

}
