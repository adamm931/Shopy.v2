using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopy.Common.Extensions;
using Shopy.Domain.Data;
using System.Threading.Tasks;

namespace Shopy.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            scope.CallService<IAuditConfigurer>(service => service.ConfigureAudit());

            if (await scope.CallServiceAsync<IDbInitializer, bool>(service => service.Init()))
            {
                await scope.CallServiceAsync<IDbSeeder>(service => service.Seed());
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
