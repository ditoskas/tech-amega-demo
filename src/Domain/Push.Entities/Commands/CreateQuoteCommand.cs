namespace Push.Entities.Commands
{
    public class CreateQuoteCommand : QuoteCommand
    {
        public CreateQuoteCommand(string symbol, string timestamp, decimal bid, decimal ask, decimal mid):base(symbol, timestamp, bid, ask, mid)
        {
           
        }
    }
}
