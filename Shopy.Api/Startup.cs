using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopy.Api.Authentication;
using Shopy.Api.Middleware;
using Shopy.Api.Services;
using Shopy.Application;
using Shopy.Application.Interfaces;
using Shopy.Infrastructure;

namespace Shopy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtAuthentication(Configuration);

            services.AddControllers();

            services.AddTransient<IProductImageUploader, ProductImageUploader>();
            services.AddTransient<ITokenProvider, TokenProvider>();

            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddValidatorsFromAssembly(typeof(IProductImageUploader).Assembly);

            services.AddLogging(builder => builder.AddFile("/Logs/Shopy-{Date}.txt"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ShopyExceptionMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
