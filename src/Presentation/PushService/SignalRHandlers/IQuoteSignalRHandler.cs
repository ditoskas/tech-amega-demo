namespace PushService.SignalRHandlers
{
    public interface IQuoteSignalRHandler
    {
        Task SendQuote(string groupName, string message);
    }
}
