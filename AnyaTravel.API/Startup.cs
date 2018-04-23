using AnyaTravel.API.AutoMapperConfig;
using AnyaTravel.BLL.Interfaces;
using AnyaTravel.BLL.Services;
using AnyaTravel.DAL.Context;
using AnyaTravel.DAL.Interfaces;
using AnyaTravel.DAL.Models;
using AnyaTravel.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AnyaTravel.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfiguration configMapper = new MapperConfiguration(
                  cfg => { cfg.AddProfile(new AutoMapperProfile()); }
              );

            services.AddMvc()
     .AddJsonOptions(options => {
        options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
            services.AddSingleton(ctx => configMapper.CreateMapper());
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityFromRepository, CityFromRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IFoodTypeRepository, FoodTypeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IPlacementTypeRepository, PlacementTypeRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourTypeRepository, TourTypeRepository>();
            services.AddScoped<ITransportTypeRepository, TransportTypeRepository>();


            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityFromService, CityFromService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IFoodTypeService, FoodTypeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IPlacementTypeService, PlacementTypeService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourTypeService, TourTypeService>();
            services.AddScoped<ITransportTypeService, TransportTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IStartDataService, StartDataService>();


            services.AddDbContext<ContextDB>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("AnyaTravel.API")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ContextDB>()
                .AddDefaultTokenProviders();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUserService userService, IStartDataService startDataService)
        {
            //userService.SeedDatabse().GetAwaiter().GetResult();
           // startDataService.AddData().GetAwaiter().GetResult();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();


            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(name: "mailpath", template: "{controller}/{action}/{id?}");
                routeBuilder.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            });
        }

    }
}

