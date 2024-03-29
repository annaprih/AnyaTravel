﻿using AnyaTravel.API.AutoMapperConfig;
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
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AnyaTravel.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfiguration configMapper = new MapperConfiguration(
                  cfg => { cfg.AddProfile(new AutoMapperProfile()); }
              );

            services.AddMvc()
     .AddJsonOptions(options =>
     {
         options.SerializerSettings.ReferenceLoopHandling =
         Newtonsoft.Json.ReferenceLoopHandling.Ignore;
     });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AnyaTravel", Version = "v1" });
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
              //  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("AnyaTravel.API")));
             options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ContextDB>()
                .AddDefaultTokenProviders();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IUserService userService,
            IStartDataService startDataService, ILoggerFactory loggerFactory)
        {
            //userService.SeedDatabse().GetAwaiter().GetResult();
            //startDataService.AddData().GetAwaiter().GetResult();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnyaTravel V1");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(name: "mailpath", template: "{controller}/{action}/{id?}");
                routeBuilder.MapSpaFallbackRoute(name: "spa-fallback", defaults: new { controller = "Home", action = "Index" });
            });
        }

    }
}

