using System;

namespace Shopy.Common
{
    public class ServiceLocator
    {
        private static IServiceProvider _provider;

        public static TService GetService<TService>()
            => (TService)_provider.GetService(typeof(TService));

        public static void SetProvider(Func<IServiceProvider> providerFactory)
        {
            _provider = providerFactory();
        }
    }
}
