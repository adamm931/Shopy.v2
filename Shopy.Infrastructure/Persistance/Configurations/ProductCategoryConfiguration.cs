using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.AddPrimaryKey();

            builder
                .HasOne(model => model.Product)
                .WithMany(model => model.Categories)
                .HasForeignKey("ProductId");

            builder
                .HasOne(model => model.Category)
                .WithMany(model => model.Products)
                .HasForeignKey("CategoryId");
        }
    }
}
