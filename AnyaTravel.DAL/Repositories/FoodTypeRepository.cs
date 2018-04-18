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
    public class FoodTypeRepository : IFoodTypeRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<FoodType> _dbSet;

        public FoodTypeRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<FoodType>();
        }

        async Task<FoodType> IRepository<FoodType, int>.Add(FoodType entity)
        {
            FoodType resFoodType;
            try
            {
                resFoodType = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resFoodType = null;
            }
            return resFoodType;
        }

        async Task<FoodType> IRepository<FoodType, int>.Delete(FoodType entity)
        {
            FoodType resFoodType;
            try
            {
                resFoodType = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resFoodType = null;
            }
            return resFoodType;
        }

        async Task<IEnumerable<FoodType>> IRepository<FoodType, int>.Get()
        {
            IEnumerable<FoodType> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<FoodType> IRepository<FoodType, int>.Get(int id)
        {
            FoodType foodType;
            try
            {
                foodType = await _dbSet.FindAsync(id);
            }
            catch
            {
                foodType = null;
            }
            return foodType;
        }

        async Task<IEnumerable<FoodType>> IRepository<FoodType, int>.Get(Func<FoodType, bool> predicate)
        {
            IEnumerable<FoodType> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<FoodType>);
            return cities;
        }

        IQueryable<FoodType> IRepository<FoodType, int>.Query()
        {
            return _dbSet;
        }

        async Task<FoodType> IRepository<FoodType, int>.Update(FoodType entity)
        {
            FoodType resFoodType;
            try
            {
                resFoodType = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resFoodType = null;
            }
            return resFoodType;
        }
    }
}
