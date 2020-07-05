using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(model => model.Brand)
                .WithMany(brand => brand.Products)
                .HasForeignKey("BrandId");
        }
    }
}