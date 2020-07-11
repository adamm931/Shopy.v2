using Microsoft.EntityFrameworkCore;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Application
{
    public static class QueriableExtensions
    {
        public static async Task<TEntity> ByExternalIdAsync<TEntity>(
            this IQueryable<TEntity> table,
            Guid externalId)
            where TEntity : Entity
            => await table.SingleOrDefaultAsync(entity => entity.ExternalId == externalId)
                ?? throw new EntityNotFoundException(typeof(TEntity).Name, externalId);
    }
}
