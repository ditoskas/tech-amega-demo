using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace LoggerService
{
    public static class LoggerExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
