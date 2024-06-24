using Contracts.DatabaseServices;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseService
{
    public static class DatabaseServiceExtensions
    {
        public static void ConfigureDatabaseServiceManager(this IServiceCollection services) => services.AddScoped<IDatabaseServiceManager, DatabaseServiceManager>();
    }
}
