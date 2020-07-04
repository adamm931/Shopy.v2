using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder
                .HasOne(model => model.Product)
                .WithMany(model => model.ProductSizes);

            builder
                .HasOne(model => model.Size)
                .WithMany(model => model.ProductSizes);
        }
    }
}
