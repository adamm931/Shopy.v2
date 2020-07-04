using Microsoft.Extensions.DependencyInjection;
using System;

namespace Shopy.Application
{
    public class ServiceLocator
    {
        private static IServiceCollection _serviceCollection;

        private static IServiceProvider _provider;
        public static IServiceProvider Provider => _provider ??= _serviceCollection.BuildServiceProvider();

        public static void SetServices(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
    }
}
