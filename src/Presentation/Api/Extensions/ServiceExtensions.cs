using Contracts;
using Contracts.DatabaseServices;
using Contracts.Repositories;
using DatabaseService;
using Microsoft.EntityFrameworkCore;
using QuotesManager;
using Repository;

namespace Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string[] hostsToAllow)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod()
                                                                  .AllowAnyHeader()
                                                                  .AllowCredentials()
                                                                  .WithOrigins(hostsToAllow));
            });
        }
        public static void ConfigureMysqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IDatabaseServiceManager, DatabaseServiceManager>();

        public static void ConfigureQuotesProvider(this IServiceCollection services) => services.AddSingleton<IQuotesProvider, QuotesProvider>();
    }
}
