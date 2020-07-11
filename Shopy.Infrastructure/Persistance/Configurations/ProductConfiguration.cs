using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(model => model.Brand, options =>
            {
                options
                    .Property(brand => brand.Code)
                    .HasColumnName("Brand")
                    .IsRequired();

                options.ToTable("Products");

            });

            builder.Metadata
                .FindNavigation("Categories")
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation("Sizes")
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}