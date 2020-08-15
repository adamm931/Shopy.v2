using Audit.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Context
{
    internal class ShopyDbContext : AuditDbContext
    {
        private readonly IOptions<ShopyDatabaseOptions> dbOptions;

        public ShopyDbContext(IOptions<ShopyDatabaseOptions> dbOptions)
        {
            this.dbOptions = dbOptions;
        }

        public DbSet<AuditLogEntry> AuditLogEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbOptions.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}