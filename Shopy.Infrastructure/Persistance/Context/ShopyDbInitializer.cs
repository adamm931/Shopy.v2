using Shopy.Domain.Data;
using System.Threading.Tasks;

namespace Shopy.Infrastructure.Persistance.Context
{
    internal class ShopyDbInitializer : IDbInitializer
    {
        private readonly ShopyDbContext context;

        public ShopyDbInitializer(ShopyDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Init() => await context.Database.EnsureCreatedAsync();
    }
}
