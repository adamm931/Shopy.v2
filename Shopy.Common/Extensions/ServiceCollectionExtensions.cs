using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void CallService<TService>(this IServiceScope scope, Action<TService> action)
        {
            var service = scope.ServiceProvider.GetService<TService>();

            action(service);
        }

        public static async Task<TResult> CallServiceAsync<TService, TResult>(this IServiceScope scope, Func<TService, Task<TResult>> action)
        {
            var service = scope.ServiceProvider.GetService<TService>();

            return await action(service);
        }

        public static async Task CallServiceAsync<TService>(this IServiceScope scope, Func<TService, Task> action)
        {
            var service = scope.ServiceProvider.GetService<TService>();

            await action(service);
        }

        public static void AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration)
            where TOptions : class
        {
            var optionsName = typeof(TOptions).Name;

            services.Configure<TOptions>(configuration.GetSection(optionsName));
        }

        public static void AddInstallers(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] sourceAssemlyTypes)
        {
            var installers = sourceAssemlyTypes
                .SelectMany(type => type.Assembly.GetTypes())
                .Where(type => typeof(IServiceInstaller).IsAssignableFrom(type))
                .Select(installerType => Activator.CreateInstance(installerType))
                .Cast<IServiceInstaller>();

            installers.Each(installer => installer.Install(services, configuration));
        }
    }
}
