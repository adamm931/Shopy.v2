using Microsoft.EntityFrameworkCore;
using Shopy.Domain.Entitties.Base;
using Shopy.Domain.Exceptions;
using System;
using System.Collections.Generic;
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

        public static async Task<TEntity> ByCodeAsync<TEntity>(
            this IQueryable<TEntity> table,
            string code)
            where TEntity : EnumEntity<TEntity>
            => await table.SingleOrDefaultAsync(entity => entity.Code == code)
                ?? throw new EntityNotFoundException(typeof(TEntity).Name, code);

        public static async Task<IQueryable<TEntity>> ByCodesAsync<TEntity>(
            this IQueryable<TEntity> table,
            IEnumerable<string> codes)
            where TEntity : EnumEntity<TEntity>
            => await Task.Run(() => table.Where(entity => codes.Contains(entity.Code)));
    }
}
