namespace Push.Entities.Events
{
    public class QuoteReceivedEvent : BaseEvent
    {
        public QuoteReceivedEvent(string symbol, DateTimeOffset timestamp, decimal bid, decimal ask, decimal mid)
        {
            Symbol = symbol;
            Timestamp = timestamp;
            Bid = bid;
            Ask = ask;
            Mid = mid;
        }
        public string Symbol { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }
        public decimal Bid { get; private set; }
        public decimal Ask { get; private set; }
        public decimal Mid { get; private set; }
    }
}
