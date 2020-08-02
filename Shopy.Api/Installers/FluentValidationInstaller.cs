using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Interfaces;
using Shopy.Common.Interfaces;

namespace Shopy.Api.Installers
{
    public sealed class FluentValidationInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(typeof(IImageService).Assembly);
        }
    }
}
