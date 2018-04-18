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
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<OrderStatus> _dbSet;

        public OrderStatusRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<OrderStatus>();
        }

        async Task<OrderStatus> IRepository<OrderStatus, int>.Add(OrderStatus entity)
        {
            OrderStatus resOrderStatus;
            try
            {
                resOrderStatus = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrderStatus = null;
            }
            return resOrderStatus;
        }

        async Task<OrderStatus> IRepository<OrderStatus, int>.Delete(OrderStatus entity)
        {
            OrderStatus resOrderStatus;
            try
            {
                resOrderStatus = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrderStatus = null;
            }
            return resOrderStatus;
        }

        async Task<IEnumerable<OrderStatus>> IRepository<OrderStatus, int>.Get()
        {
            IEnumerable<OrderStatus> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<OrderStatus> IRepository<OrderStatus, int>.Get(int id)
        {
            OrderStatus orderStatus;
            try
            {
                orderStatus = await _dbSet.FindAsync(id);
            }
            catch
            {
                orderStatus = null;
            }
            return orderStatus;
        }

        async Task<IEnumerable<OrderStatus>> IRepository<OrderStatus, int>.Get(Func<OrderStatus, bool> predicate)
        {
            IEnumerable<OrderStatus> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<OrderStatus>);
            return cities;
        }

        IQueryable<OrderStatus> IRepository<OrderStatus, int>.Query()
        {
            return _dbSet;
        }

        async Task<OrderStatus> IRepository<OrderStatus, int>.Update(OrderStatus entity)
        {
            OrderStatus resOrderStatus;
            try
            {
                resOrderStatus = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resOrderStatus = null;
            }
            return resOrderStatus;
        }
    }
}
