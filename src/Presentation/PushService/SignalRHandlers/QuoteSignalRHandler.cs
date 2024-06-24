using Microsoft.AspNetCore.SignalR;
using PushService.Hubs;

namespace PushService.SignalRHandlers
{
    public class QuoteSignalRHandler : IQuoteSignalRHandler
    {
        private readonly IHubContext<QuotesHub> _hubContext;
        public QuoteSignalRHandler(IHubContext<QuotesHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendQuote(string groupName, string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveQuote", message);
            //@todo[Dimitris] find out why the below is not working
            //await _hubContext.Clients.Group(groupName).SendAsync("receiveQuote", message);
        }


    }
}
