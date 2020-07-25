using Microsoft.EntityFrameworkCore;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties.Base;
using Shopy.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance.Repository
{

    internal class ShopyEfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ShopyDbContext context;

        public ShopyEfRepository(ShopyDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
            => (await context.Set<TEntity>().AddAsync(entity)).Entity;

        public async Task AddRange(IEnumerable<TEntity> entities)
            => await context.AddRangeAsync(entities);

        public async Task<TEntity> Get(Guid id)
            => await context.Set<TEntity>().SingleOrDefaultAsync(entity => entity.ExternalId == id);

        public Task<TEntity> Get(Specification<TEntity> specification)
            => ApplySpec(specification).SingleOrDefaultAsync(specification.Criteria);

        public async Task<IQueryable<TEntity>> List(Specification<TEntity> specification = null)
        {
            var result = ApplySpec(specification).AsNoTracking();

            if (specification != null)
            {
                result = result.Where(specification.Criteria);
            }

            return result;
        }

        public async Task Remove(TEntity entity)
            => await Task.Run(() => context.Set<TEntity>().Remove(entity));

        public async Task Remove(Guid externalId)
            => context.Set<TEntity>().Remove(await Get(externalId));

        private IQueryable<TEntity> ApplySpec(Specification<TEntity> specification)
        {
            return specification.Includes.Aggregate(
                            context.Set<TEntity>().AsQueryable(),
                            (set, include) => set.Include(include));
        }
    }
}
