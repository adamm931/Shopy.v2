using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties.Base;
using System;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public abstract class EntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity, Guid>
        where TEntity : Entity
    {
    }

    public abstract class EntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TId>
    {
        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.AddPrimaryKey();

            builder
                .HasIndex(model => model.ExternalId)
                .IsUnique();

            ConfigureEntity(builder);
        }
    }
}
