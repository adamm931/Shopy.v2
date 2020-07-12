using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shopy.Application.Interfaces;
using Shopy.Common;
using Shopy.Common.Interfaces;
using Shopy.Infrastructure.Auth;
using Shopy.Infrastructure.Common;
using Shopy.Infrastructure.Images;
using Shopy.Infrastructure.Interfaces;
using Shopy.Infrastructure.Persistance;
using Shopy.Infrastructure.Persistance.Context;
using Shopy.Infrastructure.Persistance.OnSaveHandlers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shopy.Infrastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<ShopyDatabaseOptions>(configuration);
            services.AddOptions<JwtOptions>(configuration);

            services.AddTransient<IShopySeeder, ShopySeeder>();
            services.AddTransient<IShopyContext, ShopyContext>();
            services.AddTransient<IAuthProvider, JwtTokenAuthProvider>();
            services.AddTransient<IImageUploader, ImageUploader>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddHttpContextAccessor();
            services.AddTransient<IOnSave, EntityAuditHandler>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtOptions = ServiceLocator.Provider.GetService<IOptions<JwtOptions>>().Value;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                    };
                });
        }
    }
}
