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
    public class PlacementTypeRepository : IPlacementTypeRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<PlacementType> _dbSet;

        public PlacementTypeRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<PlacementType>();
        }

        async Task<PlacementType> IRepository<PlacementType, int>.Add(PlacementType entity)
        {
            PlacementType resPlacementType;
            try
            {
                resPlacementType = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPlacementType = null;
            }
            return resPlacementType;
        }

        async Task<PlacementType> IRepository<PlacementType, int>.Delete(PlacementType entity)
        {
            PlacementType resPlacementType;
            try
            {
                resPlacementType = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPlacementType = null;
            }
            return resPlacementType;
        }

        async Task<IEnumerable<PlacementType>> IRepository<PlacementType, int>.Get()
        {
            IEnumerable<PlacementType> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<PlacementType> IRepository<PlacementType, int>.Get(int id)
        {
            PlacementType placementType;
            try
            {
                placementType = await _dbSet.FindAsync(id);
            }
            catch
            {
                placementType = null;
            }
            return placementType;
        }

        async Task<IEnumerable<PlacementType>> IRepository<PlacementType, int>.Get(Func<PlacementType, bool> predicate)
        {
            IEnumerable<PlacementType> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<PlacementType>);
            return cities;
        }

        IQueryable<PlacementType> IRepository<PlacementType, int>.Query()
        {
            return _dbSet;
        }

        async Task<PlacementType> IRepository<PlacementType, int>.Update(PlacementType entity)
        {
            PlacementType resPlacementType;
            try
            {
                resPlacementType = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resPlacementType = null;
            }
            return resPlacementType;
        }
    }
}
