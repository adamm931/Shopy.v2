using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Common.Interfaces;

namespace Shopy.Api.Installers
{
    public sealed class MvcInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMvc()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        }
    }
}
