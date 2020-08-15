using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class AuditLogEntryConfiguration : EntityTypeConfiguration<AuditLogEntry>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<AuditLogEntry> builder)
        {
            builder.OwnsOne(model => model.Table, table =>
            {
                table.Property(model => model.Name).HasColumnName("Table");
            });

            builder.OwnsOne(model => model.Action, table =>
            {
                table.Property(model => model.Name).HasColumnName("Action");
            });
        }
    }
}
