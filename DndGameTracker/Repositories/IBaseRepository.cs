using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

        Task UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken);
    }
}
