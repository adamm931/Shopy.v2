using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            var initilizer = scope.ServiceProvider.GetService<IDbInitializer>();

            if (await initilizer.Init())
            {
                var seeder = scope.ServiceProvider.GetService<IDbSeeder>();
                await seeder.Seed();
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
