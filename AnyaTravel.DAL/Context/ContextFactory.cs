using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnyaTravel.DAL.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TravelCompany;Integrated Security=True;Connection Timeout=300");
            optionsBuilder.UseNpgsql("Server=ec2-23-23-248-192.compute-1.amazonaws.com;Port=5432;Database=dblevctsp00pik;User Id=znsthgrzswhkmo;Password=42ebfccebec631d93f93b97fb99b0b695b03766c83cd365806ed200957befbbf;SSL Mode=Require;Trust Server Certificate=true;");
            return new ContextDB(optionsBuilder.Options);
        }
    }
}
