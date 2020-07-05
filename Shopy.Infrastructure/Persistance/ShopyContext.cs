using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopy.Application.Interfaces;
using Shopy.Domain.Entitties;
using Shopy.Infrastructure.Persistance.EntityAudit;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance
{
    public class ShopyContext : DbContext, IShopyContext
    {
        private readonly IOptions<ShopyDatabaseOptions> _options;
        private readonly IEfCoreEntityAudit _entityAudit;

        public ShopyContext(
            IOptions<ShopyDatabaseOptions> options,
            IEfCoreEntityAudit entityAudit)
        {
            _options = options;
            _entityAudit = entityAudit;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task Save()
        {
            _entityAudit.Audit(ChangeTracker);

            await SaveChangesAsync();
        }

        public async Task<bool> IsCreated()
        {
            return !await Database.EnsureCreatedAsync();
        }
    }
}