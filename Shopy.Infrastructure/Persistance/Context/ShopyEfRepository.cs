using Microsoft.EntityFrameworkCore;
using Shopy.Common.Extensions;
using Shopy.Common.Paging;
using Shopy.Domain.Data;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Specification;
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

        public async Task<long> Count(ISpecification<TEntity> specification)
            => await ApplySpec(specification).CountAsync();

        public async Task<TEntity> Get(Guid id)
            => await context.Set<TEntity>().SingleOrDefaultAsync(entity => entity.ExternalId == id);

        public async Task<TEntity> Get(ISpecification<TEntity> specification)
            => await ApplySpec(specification).SingleOrDefaultAsync(specification.Criteria);

        public async Task<IQueryable<TEntity>> List(ISpecification<TEntity> specification = null)
            => await Task.Run(() => ApplySpec(specification ?? new Specification<TEntity>()).AsNoTracking());

        public async Task<IPagedList<TEntity>> PagedList(IPagedSpecification<TEntity> specification)
        {
            var items = ApplySpec(specification);
            var count = await ApplySpec(specification).CountAsync();

            var pageIndex = specification.PageIndex ?? 0;
            var pageSize = specification.PageSize ?? count;

            return items.ToPagedList(pageIndex, pageSize, count);
        }

        public async Task Remove(TEntity entity)
            => await Task.Run(() => context.Set<TEntity>().Remove(entity));

        public async Task Remove(Guid externalId)
            => context.Set<TEntity>().Remove(await Get(externalId));

        private IQueryable<TEntity> ApplySpec<TSpec>(ISpecification<TEntity, TSpec> specification)
            where TSpec : ISpecification<TEntity, TSpec>
            => specification.Includes
                .Aggregate(context.Set<TEntity>().AsQueryable(), (set, include) => set.Include(include))
                .Where(specification.Criteria);
    }
}
