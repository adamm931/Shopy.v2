using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Application.Pipelines;
using Shopy.Application.Products.Add;
using Shopy.Common;

namespace Shopy.Application
{
    public static class Installer
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            services.AddMediatR(typeof(AddProductCommand).Assembly);
            services.AddAutoMapper(typeof(AddProductCommand).Assembly);

            ServiceLocator.SetProvider(services.BuildServiceProvider);
        }
    }
}
