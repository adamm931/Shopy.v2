using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.AddPrimaryKey();

            builder
                .HasOne(model => model.Product)
                .WithMany(model => model.ProductSizes)
                .HasForeignKey("ProductId");

            builder
                .HasOne(model => model.Size)
                .WithMany(model => model.ProductSizes)
                .HasForeignKey("SizeId");
        }
    }
}
