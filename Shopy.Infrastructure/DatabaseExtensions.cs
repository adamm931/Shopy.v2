using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties.Base;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Infrastructure
{
    public static class DatabaseExtensions
    {
        public static void AddPrimaryKey<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class
        {
            builder.Property<long>("Id");
            builder.HasKey("Id");
        }

        public static void AddDeletedQueryFilter<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, ISoftDelete
            => builder.HasQueryFilter(model => !model.Deleted);

        public static IEnumerable<EntityEntry<TEntityType>> EntityEntriesByState<TEntityType>(this ChangeTracker changeTracker, EntityState state)
            where TEntityType : class
            => changeTracker
                .Entries<TEntityType>()
                .Where(entry => state == entry.State);
    }
}
