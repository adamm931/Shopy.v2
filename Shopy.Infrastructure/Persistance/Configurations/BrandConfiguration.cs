using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class BrandConfiguration : EntityTypeConfiguration<Brand>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Brand> builder)
        {
        }
    }
}
