using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shopy.Api.Common;
using Shopy.Api.Filters;
using Shopy.Common.Interfaces;

namespace Shopy.Api.Installers
{
    public sealed class SwaggerInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddSwaggerGen(swagger =>
                {
                    swagger.DescribeAllParametersInCamelCase();
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Shopy api",
                        Version = "v1"
                    });

                    swagger.AddSecurityDefinition(ApiConstants.Bearer, new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = ApiConstants.Bearer,
                    });

                    swagger.OperationFilter<SwaggerOperationFilter>();
                });
        }
    }
}
