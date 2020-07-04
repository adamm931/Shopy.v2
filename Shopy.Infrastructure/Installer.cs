using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Interfaces;
using Shopy.Infrastructure.Persistance;
using Shopy.Infrastructure.Persistance.Options;

namespace Shopy.Infrastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ShopyDatabaseOptions>(configuration.GetSection(ShopyDatabaseOptions.Name));
            services.AddTransient<IShopySeeder, ShopySeeder>();
            services.AddTransient<IShopyContext, ShopyContext>();
        }
    }
}
