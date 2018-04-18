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
    public class CityRepository : ICityRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<City> _dbSet;

        public CityRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<City>();
        }

        async Task<City> IRepository<City, int>.Add(City entity)
        {
            City resCity;
            try
            {
                resCity = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCity = null;
            }
            return resCity;
        }

        async Task<City> IRepository<City, int>.Delete(City entity)
        {
            City resCity;
            try
            {
                resCity = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCity = null;
            }
            return resCity;
        }

        async Task<IEnumerable<City>> IRepository<City, int>.Get()
        {
            IEnumerable<City> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<City> IRepository<City, int>.Get(int id)
        {
            City city;
            try
            {
                city = await _dbSet.FindAsync(id);
            }
            catch
            {
                city = null;
            }
            return city;
        }

        async Task<IEnumerable<City>> IRepository<City, int>.Get(Func<City, bool> predicate)
        {
            IEnumerable<City> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<City>);
            return cities;
        }

        IQueryable<City> IRepository<City, int>.Query()
        {
            return _dbSet;
        }

        async Task<City> IRepository<City, int>.Update(City entity)
        {
            City resCity;
            try
            {
                resCity = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCity = null;
            }
            return resCity;
        }
    }
}
