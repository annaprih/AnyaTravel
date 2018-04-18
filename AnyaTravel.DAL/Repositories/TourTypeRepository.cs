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
    public class TourTypeRepository : ITourTypeRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<TourType> _dbSet;

        public TourTypeRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<TourType>();
        }

        async Task<TourType> IRepository<TourType, int>.Add(TourType entity)
        {
            TourType resTourType;
            try
            {
                resTourType = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTourType = null;
            }
            return resTourType;
        }

        async Task<TourType> IRepository<TourType, int>.Delete(TourType entity)
        {
            TourType resTourType;
            try
            {
                resTourType = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTourType = null;
            }
            return resTourType;
        }

        async Task<IEnumerable<TourType>> IRepository<TourType, int>.Get()
        {
            IEnumerable<TourType> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<TourType> IRepository<TourType, int>.Get(int id)
        {
            TourType tourType;
            try
            {
                tourType = await _dbSet.FindAsync(id);
            }
            catch
            {
                tourType = null;
            }
            return tourType;
        }

        async Task<IEnumerable<TourType>> IRepository<TourType, int>.Get(Func<TourType, bool> predicate)
        {
            IEnumerable<TourType> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<TourType>);
            return cities;
        }

        IQueryable<TourType> IRepository<TourType, int>.Query()
        {
            return _dbSet;
        }

        async Task<TourType> IRepository<TourType, int>.Update(TourType entity)
        {
            TourType resTourType;
            try
            {
                resTourType = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTourType = null;
            }
            return resTourType;
        }
    }
}
