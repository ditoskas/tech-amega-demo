namespace Push.Entities.Commands
{
    public abstract class QuoteCommand : BaseCommand
    {
        protected QuoteCommand(string symbol, string timestamp, decimal bid, decimal ask, decimal mid)
        {
            Symbol = symbol;
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(timestamp));
            Bid = bid;
            Ask = ask;
            Mid = mid;
        }
        public string Symbol { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
        public decimal Bid { get; protected set; }
        public decimal Ask { get; protected set; }
        public decimal Mid { get; protected set; }
    }
}
