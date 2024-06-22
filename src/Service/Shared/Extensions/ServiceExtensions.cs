using Contracts;
using LoggerService;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
