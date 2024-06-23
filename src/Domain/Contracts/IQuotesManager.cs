using Contracts.DataTransferObjects;

namespace Contracts
{
    public interface IQuotesProvider
    {
        Task<LastPriceDto> GetLastPriceAsync(string pair);
        Task<TickerDto> GetTickerAsync(string pair);

    }
}
