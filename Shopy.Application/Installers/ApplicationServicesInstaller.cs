using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Pipelines;
using Shopy.Application.Products.Add;
using Shopy.Common;

namespace Shopy.Application.Installers
{
    public sealed class ApplicationServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipeline<,>));

            services.AddMediatR(typeof(AddProductCommand).Assembly);
            services.AddAutoMapper(typeof(AddProductCommand).Assembly);
        }
    }
}
