using Microsoft.Extensions.DependencyInjection;
using Push.Entities.Bus;

namespace QueueService
{
    public static class QueueServiceExtensions
    {
        public static void ConfigureQueueRegisterServices(this IServiceCollection services) => services.AddTransient<IEventBus, RabbitMqBus>();
    }
}
