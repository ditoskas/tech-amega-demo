using MediatR;
using Push.Entities.Bus;
using Push.Entities.Commands;
using Push.Entities.Events;

namespace Push.Entities.CommandHandlers
{
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public CreateQuoteCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            //Publish the event to the bus
            _eventBus.Publish(new QuoteReceivedEvent(request.Symbol, request.Timestamp, request.Bid, request.Ask, request.Mid));
            return Task.FromResult(true);
        }
    }
}
