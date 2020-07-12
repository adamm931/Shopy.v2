using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopy.Application.Interfaces;
using Shopy.Common;
using Shopy.Domain.Entitties;
using Shopy.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance.Context
{
    partial class ShopyContext : DbContext, IShopyContext
    {
        private readonly IOptions<ShopyDatabaseOptions> _options;
        private readonly IEnumerable<IOnSave> _saveEventHandlers;

        public ShopyContext(
            IOptions<ShopyDatabaseOptions> options,
            IEnumerable<IOnSave> saveEventHandlers)
        {
            _options = options;
            _saveEventHandlers = saveEventHandlers;
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

        public async Task Save()
        {
            _saveEventHandlers.Each(handler => handler.OnSave(this));

            await SaveChangesAsync();
        }

        public async Task<bool> IsCreated()
        {
            return !await Database.EnsureCreatedAsync();
        }
    }
}