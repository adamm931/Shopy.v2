using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopy.Application.Interfaces;
using Shopy.Domain.Entitties;
using Shopy.Infrastructure.Persistance.Options;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance
{
    public class ShopyContext : DbContext, IShopyContext
    {
        private readonly IOptions<ShopyDatabaseOptions> options;

        public ShopyContext(IOptions<ShopyDatabaseOptions> options)
        {
            this.options = options;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public async Task Save()
        {
            await SaveChangesAsync();
        }

        public async Task<bool> IsCreated()
        {
            return !await Database.EnsureCreatedAsync();
        }
    }
}