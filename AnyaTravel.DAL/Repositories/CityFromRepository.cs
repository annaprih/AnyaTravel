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
    public class CityFromRepository : ICityFromRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<CityFrom> _dbSet;

        public CityFromRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<CityFrom>();
        }

        async Task<CityFrom> IRepository<CityFrom, int>.Add(CityFrom entity)
        {
            CityFrom resCityFrom;
            try
            {
                resCityFrom = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCityFrom = null;
            }
            return resCityFrom;
        }

        async Task<CityFrom> IRepository<CityFrom, int>.Delete(CityFrom entity)
        {
            CityFrom resCityFrom;
            try
            {
                resCityFrom = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCityFrom = null;
            }
            return resCityFrom;
        }

        async Task<IEnumerable<CityFrom>> IRepository<CityFrom, int>.Get()
        {
            IEnumerable<CityFrom> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<CityFrom> IRepository<CityFrom, int>.Get(int id)
        {
            CityFrom cityFrom;
            try
            {
                cityFrom = await _dbSet.FindAsync(id);
            }
            catch
            {
                cityFrom = null;
            }
            return cityFrom;
        }

        async Task<IEnumerable<CityFrom>> IRepository<CityFrom, int>.Get(Func<CityFrom, bool> predicate)
        {
            IEnumerable<CityFrom> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<CityFrom>);
            return cities;
        }

        IQueryable<CityFrom> IRepository<CityFrom, int>.Query()
        {
            return _dbSet;
        }

        async Task<CityFrom> IRepository<CityFrom, int>.Update(CityFrom entity)
        {
            CityFrom resCityFrom;
            try
            {
                resCityFrom = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCityFrom = null;
            }
            return resCityFrom;
        }
    }
}
