using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    interface IService<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> ReadAll();
        Task<IEnumerable<TEntity>> Read(Func<TEntity, bool> predicate);
        Task<TEntity> ReadById(TKey id);
        Task<TEntity> Create(TEntity item);
        Task<TEntity> Update(TEntity item);
        Task<TEntity> Delete(TKey id);


    }
}
