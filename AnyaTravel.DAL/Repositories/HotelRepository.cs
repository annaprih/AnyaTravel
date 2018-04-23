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
    public class HotelRepository : IHotelRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<Hotel> _dbSet;

        public HotelRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<Hotel>();
            _dbSet.Load();
        }

        async Task<Hotel> IRepository<Hotel, int>.Add(Hotel entity)
        {
            Hotel resHotel;
            try
            {
                resHotel = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHotel = null;
            }
            return resHotel;
        }

        async Task<Hotel> IRepository<Hotel, int>.Delete(Hotel entity)
        {
            Hotel resHotel;
            try
            {
                resHotel = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHotel = null;
            }
            return resHotel;
        }

        async Task<IEnumerable<Hotel>> IRepository<Hotel, int>.Get()
        {
            IEnumerable<Hotel> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<Hotel> IRepository<Hotel, int>.Get(int id)
        {
            Hotel hotel;
            try
            {
                hotel = await _dbSet.FindAsync(id);
            }
            catch
            {
                hotel = null;
            }
            return hotel;
        }

        async Task<IEnumerable<Hotel>> IRepository<Hotel, int>.Get(Func<Hotel, bool> predicate)
        {
            IEnumerable<Hotel> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<Hotel>);
            return cities;
        }

        IQueryable<Hotel> IRepository<Hotel, int>.Query()
        {
            return _dbSet;
        }

        async Task<Hotel> IRepository<Hotel, int>.Update(Hotel entity)
        {
            Hotel resHotel;
            try
            {
                resHotel = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resHotel = null;
            }
            return resHotel;
        }
    }
}
