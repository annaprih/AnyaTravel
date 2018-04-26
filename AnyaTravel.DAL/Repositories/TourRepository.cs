using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyaTravel.DAL.Context;
using AnyaTravel.DAL.Interfaces;
using AnyaTravel.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AnyaTravel.DAL.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<Tour> _dbSet;

        public TourRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<Tour>();
            _dbSet.Load();
        }

        async Task<Tour> IRepository<Tour, int>.Add(Tour entity)
        {
            Tour resTour;
            try
            {
                resTour = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTour = null;
            }
            return resTour;
        }

        async Task<Tour> IRepository<Tour, int>.Delete(Tour entity)
        {
            Tour resTour;
            try
            {
                resTour = await _dbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);
                resTour = _dbSet.Remove(resTour).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTour = null;
            }
            return resTour;
        }

        async Task<IEnumerable<Tour>> IRepository<Tour, int>.Get()
        {
            IEnumerable<Tour> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<Tour> IRepository<Tour, int>.Get(int id)
        {
            Tour tour;
            try
            {
                tour = await Task.Factory.StartNew(() => _dbSet.Include(p => p.Hotel.PlacementType).Where(t => t.Id == id).FirstOrDefault());
            }
            catch
            {
                tour = null;
            }
            return tour;
        }

        async Task<IEnumerable<Tour>> IRepository<Tour, int>.Get(Func<Tour, bool> predicate)
        {
            IEnumerable<Tour> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<Tour>);
            return cities;
        }

        IQueryable<Tour> IRepository<Tour, int>.Query()
        {
            return _dbSet;
        }

        async Task<Tour> IRepository<Tour, int>.Update(Tour entity)
        {
            Tour resTour;
            try
            {
                resTour = await _dbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);
                await MoveTourProperties(entity, resTour);
                resTour = _dbSet.Update(resTour).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTour = null;
            }
            return resTour;
        }

        private async Task MoveTourProperties(Tour entity, Tour resTour)
        {
            resTour.CityFrom = await _context.CitiesFrom.FirstOrDefaultAsync(p => p.Id == entity.CityFrom.Id);
            resTour.CountOfTours = entity.CountOfTours;
            resTour.DateFrom = entity.DateFrom;
            resTour.DateTo = entity.DateTo;
            resTour.FoodType = await _context.FoodTypes.FirstOrDefaultAsync(p => p.Id == entity.FoodType.Id);
            resTour.Hotel = await _context.Hotels.FirstOrDefaultAsync(p => p.Id == entity.Hotel.Id);
            resTour.Price = entity.Price;
            resTour.TransportType = await _context.TransportTypes.FirstOrDefaultAsync(p => p.Id == entity.TransportType.Id);
        }
    }
}
