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
    public class OrderRepository : IOrderRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
            _dbSet.Load();
        }

        async Task<Order> IRepository<Order, int>.Add(Order entity)
        {
            Order resOrder;
            try
            {
                resOrder = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrder = null;
            }
            return resOrder;
        }

        async Task<Order> IRepository<Order, int>.Delete(Order entity)
        {
            Order resOrder;
            try
            {
                resOrder = await _dbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);
                resOrder = _dbSet.Remove(resOrder).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrder = null;
            }
            return resOrder;
        }

        async Task<IEnumerable<Order>> IRepository<Order, int>.Get()
        {
            IEnumerable<Order> orders = await _dbSet.Include(p => p.User)
            .Include(p => p.Tour.CityFrom).Include(p => p.Tour.FoodType).Include(p => p.Tour.Hotel.City)
            .Include(p => p.OrderStatus).ToListAsync();
            return orders;
        }

        async Task<Order> IRepository<Order, int>.Get(int id)
        {
            Order order;
            try
            {
                order = await Task.Factory.StartNew(() => _dbSet.Include(p => p.User).Where(o => o.Id == id).FirstOrDefault());
            }
            catch
            {
                order = null;
            }
            return order;
        }

        async Task<IEnumerable<Order>> IRepository<Order, int>.Get(Func<Order, bool> predicate)
        {
            IEnumerable<Order> cities = await Task.Factory.StartNew(() => _dbSet.Include(p => p.User)
            .Include(p => p.Tour.CityFrom).Include(p => p.Tour.FoodType).Include(p => p.Tour.Hotel.City)
            .Include(p => p.OrderStatus)
            .Where(predicate).ToList() as IEnumerable<Order>);
            return cities;
        }

        IQueryable<Order> IRepository<Order, int>.Query()
        {
            return _dbSet;
        }

        async Task<Order> IRepository<Order, int>.Update(Order entity)
        {
            Order resOrder;
            try
            {
               resOrder  = await _dbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);
                resOrder.OrderStatus = entity.OrderStatus;
                resOrder = _dbSet.Update(resOrder).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrder = null;
            }
            return resOrder;
        }
    }
}
