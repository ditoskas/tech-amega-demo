using Contracts.DataTransferObjects;

namespace Contracts.DatabaseServices
{
    public interface IQuoteService
    {
        Task<QuoteDto> CreateQuoteAsync(QuoteForCreationDto company);
    }
}
