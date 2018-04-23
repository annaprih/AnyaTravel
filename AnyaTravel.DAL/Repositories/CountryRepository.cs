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
    public class CountryRepository : ICountryRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<Country> _dbSet;

        public CountryRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<Country>();
            _dbSet.Load();
        }

        async Task<Country> IRepository<Country, int>.Add(Country entity)
        {
            Country resCountry;
            try
            {
                resCountry = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCountry = null;
            }
            return resCountry;
        }

        async Task<Country> IRepository<Country, int>.Delete(Country entity)
        {
            Country resCountry;
            try
            {
                resCountry = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCountry = null;
            }
            return resCountry;
        }

        async Task<IEnumerable<Country>> IRepository<Country, int>.Get()
        {
            IEnumerable<Country> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<Country> IRepository<Country, int>.Get(int id)
        {
            Country country;
            try
            {
                country = await _dbSet.FindAsync(id);
            }
            catch
            {
                country = null;
            }
            return country;
        }

        async Task<IEnumerable<Country>> IRepository<Country, int>.Get(Func<Country, bool> predicate)
        {
            IEnumerable<Country> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<Country>);
            return cities;
        }

        IQueryable<Country> IRepository<Country, int>.Query()
        {
            return _dbSet;
        }

        async Task<Country> IRepository<Country, int>.Update(Country entity)
        {
            Country resCountry;
            try
            {
                resCountry = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resCountry = null;
            }
            return resCountry;
        }
    }
}
