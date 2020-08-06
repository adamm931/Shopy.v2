using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Common;
using Shopy.Common.Extensions;
using Shopy.Domain.Data;
using Shopy.Infrastructure.Interfaces;
using Shopy.Infrastructure.Persistance;
using Shopy.Infrastructure.Persistance.Context;
using Shopy.Infrastructure.Persistance.OnSaveHandlers;
using Shopy.Infrastructure.Persistance.Repository;

namespace Shopy.Infrastructure.Installers
{
    public sealed class DatabaseInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<ShopyDatabaseOptions>(configuration);
            services.AddSingleton<ShopyDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbInitializer, ShopyDbInitializer>();
            services.AddTransient<IDbSeeder, ShopyDbSeeder>();
            services.AddTransient(typeof(IRepository<>), typeof(ShopyEfRepository<>));
            services.AddTransient<IOnSaveHandler, EntityAuditHandler>();
        }
    }
}
