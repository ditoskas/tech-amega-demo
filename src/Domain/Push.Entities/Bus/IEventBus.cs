using Push.Entities.Commands;
using Push.Entities.Events;

namespace Push.Entities.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : BaseCommand;
        void Publish<T>(T @event) where T : BaseEvent;
        void Subscribe<T, TH>()
            where T : BaseEvent
            where TH : IEventHandler<T>;
    }
}
