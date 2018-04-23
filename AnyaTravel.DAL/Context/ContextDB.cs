using AnyaTravel.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyaTravel.DAL.Context
{
    public class ContextDB : IdentityDbContext<User>
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<CityFrom> CitiesFrom { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PlacementType> PlacementTypes { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<TransportType> TransportTypes { get; set; }

    }
}
