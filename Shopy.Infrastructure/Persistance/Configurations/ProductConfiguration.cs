using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.AddDeletedQueryFilter();

            builder.OwnsOne(model => model.Brand, options =>
            {
                options
                    .Property(brand => brand.Code)
                    .HasColumnName("Brand");
            });
        }
    }
}