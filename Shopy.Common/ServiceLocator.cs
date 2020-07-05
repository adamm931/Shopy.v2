using System;

namespace Shopy.Common
{
    public class ServiceLocator
    {
        public static IServiceProvider Provider { get; private set; }

        public static void SetProvider(Func<IServiceProvider> providerFactory)
        {
            Provider = providerFactory();
        }
    }
}
