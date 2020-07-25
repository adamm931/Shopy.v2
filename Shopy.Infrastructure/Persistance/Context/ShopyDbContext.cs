using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Context
{
    internal class ShopyDbContext : DbContext
    {
        private readonly IOptions<ShopyDatabaseOptions> _options;

        public ShopyDbContext(IOptions<ShopyDatabaseOptions> options)
        {
            _options = options;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}