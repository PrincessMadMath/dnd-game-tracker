using DndGameTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await applicationDbContext.AddAsync(entity, cancellationToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.applicationDbContext.Set<TEntity>();
        }

        public async Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken)
        {
            return await this.applicationDbContext.FindAsync<TEntity>(keyValues, cancellationToken);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.applicationDbContext.Update(entity);
            await this.applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task UpdateRangeAsync(List<TEntity> entities, CancellationToken cancellationToken)
        {
            this.applicationDbContext.UpdateRange(entities);
            await this.applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.applicationDbContext.Remove(entity);
            await this.applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
