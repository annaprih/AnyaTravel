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
    public class TransportTypeRepository : ITransportTypeRepository
    {
        private readonly ContextDB _context;
        private readonly DbSet<TransportType> _dbSet;

        public TransportTypeRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<TransportType>();
        }

        async Task<TransportType> IRepository<TransportType, int>.Add(TransportType entity)
        {
            TransportType resTransportType;
            try
            {
                resTransportType = (await _dbSet.AddAsync(entity)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTransportType = null;
            }
            return resTransportType;
        }

        async Task<TransportType> IRepository<TransportType, int>.Delete(TransportType entity)
        {
            TransportType resTransportType;
            try
            {
                resTransportType = _dbSet.Remove(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTransportType = null;
            }
            return resTransportType;
        }

        async Task<IEnumerable<TransportType>> IRepository<TransportType, int>.Get()
        {
            IEnumerable<TransportType> cities = await _dbSet.ToListAsync();
            return cities;
        }

        async Task<TransportType> IRepository<TransportType, int>.Get(int id)
        {
            TransportType transportType;
            try
            {
                transportType = await _dbSet.FindAsync(id);
            }
            catch
            {
                transportType = null;
            }
            return transportType;
        }

        async Task<IEnumerable<TransportType>> IRepository<TransportType, int>.Get(Func<TransportType, bool> predicate)
        {
            IEnumerable<TransportType> cities = await Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<TransportType>);
            return cities;
        }

        IQueryable<TransportType> IRepository<TransportType, int>.Query()
        {
            return _dbSet;
        }

        async Task<TransportType> IRepository<TransportType, int>.Update(TransportType entity)
        {
            TransportType resTransportType;
            try
            {
                resTransportType = _dbSet.Update(entity).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                resTransportType = null;
            }
            return resTransportType;
        }
    }
}
