using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopy.Infrastructure
{
    public static class EntityBuilderExtensions
    {
        public static void AddPrimaryKey<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class
        {
            builder.Property<long>("Id");
            builder.HasKey("Id");
        }
    }
}
