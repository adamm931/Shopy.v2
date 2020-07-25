using Shopy.Domain.Entitties.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Domain.Data
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Get(Guid externalId);

        Task<TEntity> Get(Specification<TEntity> specification);

        Task<TEntity> Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        Task Remove(TEntity entity);

        Task Remove(Guid externalId);

        Task<IQueryable<TEntity>> List(Specification<TEntity> specification = null);
    }
}
