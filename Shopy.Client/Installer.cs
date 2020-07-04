using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Client.Api;
using Shopy.Client.Clients;
using Shopy.Client.Config;
using Shopy.Client.Interfaces;

namespace Shopy.Client
{
    public static class Installer
    {
        public static void AddShopyClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ShopyClientOptions>(configuration.GetSection("ShopyClientSettings"));

            services
                .AddHttpClient<IShopyHttpClient, ShopyHttpClient>()
                .AddHttpMessageHandler<ShopyResponseMessageHandler>();

            services.AddTransient<IProductsApi, ProductsApi>();
            services.AddTransient<ICategoriesApi, CategoriesApi>();
            services.AddTransient<IBrandsApi, BrandsApi>();
            services.AddTransient<ISizesApi, SizesApi>();

        }
    }
}
