using Contracts;
using Contracts.DatabaseServices;
using Contracts.Repositories;
using DatabaseService;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Shared.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureMysqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IDatabaseServiceManager, DatabaseServiceManager>();
    }
}
