using Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Push.Entities.Bus;
using Push.Entities.CommandHandlers;
using Push.Entities.Commands;

namespace QueueService
{
    public static class QueueServiceExtensions
    {
        public static void ConfigureQueueServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMqBus(sp.GetRequiredService<IMediator>(), sp.GetRequiredService<ILoggerManager>(), scopeFactory);
            });
            services.AddTransient<IRequestHandler<CreateQuoteCommand, bool>, CreateQuoteCommandHandler>();
        }
    }
}
