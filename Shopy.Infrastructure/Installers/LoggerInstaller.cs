using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shopy.Common;

namespace Shopy.Infrastructure.Installers
{
    public class LoggerInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(builder => builder.AddFile("/Logs/Shopy-{Date}.txt"));
        }
    }
}
