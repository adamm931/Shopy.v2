using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Interfaces;
using Shopy.Common;
using Shopy.Common.Interfaces;
using Shopy.Infrastructure.Auth;
using Shopy.Infrastructure.Common;
using Shopy.Infrastructure.Crypto;
using Shopy.Infrastructure.Images;

namespace Shopy.Infrastructure.Installers
{
    public class ServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAuthProvider, AuthProvider>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IEncoder, Base64Encoder>();
            services.AddTransient<IEncryption, Sha512ManagedEncryption>();
            services.AddHttpContextAccessor();
        }
    }
}
