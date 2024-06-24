namespace Contracts.DatabaseServices
{
    public interface IDatabaseServiceManager
    {
        IInstrumentPairService InstrumentPairService { get; }
        IQuoteService QuoteService { get; }
    }
}
