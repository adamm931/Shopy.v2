using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Interfaces;
using Shopy.Common.Interfaces;
using Shopy.Infrastructure.Auth;
using Shopy.Infrastructure.Common;
using Shopy.Infrastructure.Images;

namespace Shopy.Infrastructure.Installers
{
    public class ServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthProvider, JwtTokenAuthProvider>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddHttpContextAccessor();
        }
    }
}
