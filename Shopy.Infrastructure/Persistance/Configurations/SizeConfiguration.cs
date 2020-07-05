using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class SizeConfiguration : EntityTypeConfiguration<Size>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Size> builder)
        {
        }
    }
}
