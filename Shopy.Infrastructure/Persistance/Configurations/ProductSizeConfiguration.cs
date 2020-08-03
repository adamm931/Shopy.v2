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
                .WithMany(product => product.Sizes)
                .HasForeignKey("ProductId");


            builder.OwnsOne(model => model.Size, options =>
            {
                options
                    .Property(brand => brand.Code)
                    .HasColumnName("Size");
            });
        }
    }
}
