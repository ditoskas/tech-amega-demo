using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{
    public static class RepositoryExtensions
    {
        public static void ConfigureMysqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) => services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
