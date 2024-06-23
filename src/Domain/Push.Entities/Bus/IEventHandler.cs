using Push.Entities.Events;

namespace Push.Entities.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : BaseEvent
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
