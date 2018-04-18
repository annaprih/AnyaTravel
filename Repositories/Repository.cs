using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Context;
using Microsoft.EntityFrameworkCore;


namespace DataBase.Repositories
{
    public class Repository<TEntity, TKey> where TEntity : class
    {
        protected readonly ContextDB _context;

        protected readonly DbSet<TEntity> _dbSet;

        public DbSet<TEntity> DbSet
        {
            get
            {
                return _dbSet;
            }
        }

        public Repository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Task<IEnumerable<TEntity>> ReadAll()
        {
            return Task.Factory.StartNew(() => _dbSet.ToList() as IEnumerable<TEntity>);
        }

        public Task<IEnumerable<TEntity>> Read(Func<TEntity, bool> predicate)
        {
            return Task.Factory.StartNew(() => _dbSet.Where(predicate).ToList() as IEnumerable<TEntity>);
        }
        public Task<TEntity> ReadById(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity item)
        {
            TEntity entity;

            try
            {
                entity = _dbSet.Add(item).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                entity = null;
            }

            return entity;
        }

        public async Task<TEntity> Update(TEntity item)
        {
            TEntity entity;

            try
            {
                entity = _dbSet.Update(item).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                entity = null;
            }

            return entity;
        }

        public async Task<TEntity> Delete(TKey id)
        {
            TEntity entity;

            try
            {
                entity = _dbSet.Remove(_dbSet.Find(id)).Entity;
                await _context.SaveChangesAsync();
            }
            catch
            {
                entity = null;
            }

            return entity;
        }

    }
}
