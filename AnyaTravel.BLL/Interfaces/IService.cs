using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyaTravel.BLL.Interfaces
{
    public interface IService<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate);
        Task<TEntity> Get(TKey id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}
