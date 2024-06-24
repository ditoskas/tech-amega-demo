using Contracts.DatabaseServices;
using Contracts.DataTransferObjects;
using Push.Entities.Bus;
using Push.Entities.Events;
using PushService.SignalRHandlers;
using Shared.Utilities;

namespace PushService.EventHandlers
{
    public class QuoteReceivedEventHandler : IEventHandler<QuoteReceivedEvent>
    {
        IDatabaseServiceManager _databaseServiceManager;
        IQuoteSignalRHandler _quoteSignalRHandler;
        public QuoteReceivedEventHandler(IDatabaseServiceManager databaseServiceManager, IQuoteSignalRHandler quoteSignalRHandler)
        {
            _databaseServiceManager = databaseServiceManager;
            _quoteSignalRHandler = quoteSignalRHandler;
        }
        /// <summary>
        /// When we receive a quote, save it to database and send it to the clients via signalr
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task Handle(QuoteReceivedEvent @event)
        {
            //Save to database
            QuoteForCreationDto quote = new QuoteForCreationDto(@event.Symbol, @event.Timestamp, @event.Bid, @event.Ask, @event.Mid);
            await _databaseServiceManager.QuoteService.CreateQuoteAsync(quote);
            //Send to clients
            await _quoteSignalRHandler.SendQuote(@event.Symbol, Serializer.Serialize(quote));

        }
    }
}
