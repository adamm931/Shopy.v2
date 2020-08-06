using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Shopy.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
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
