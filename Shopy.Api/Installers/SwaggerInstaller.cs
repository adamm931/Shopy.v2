using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Shopy.Common.Interfaces;
using System.Collections.Generic;

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

                    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                    });

                    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new List<string>()
                        }
                    });
                });
        }
    }
}
