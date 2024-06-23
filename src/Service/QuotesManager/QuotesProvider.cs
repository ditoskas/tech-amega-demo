using CexService;
using CexService.Responses;
using Contracts;
using Contracts.DataTransferObjects;
using Entities.Exceptions;

namespace QuotesManager
{
    /// <summary>
    /// Wrapper class for quotes, it execute the request to the provider and return standard response
    /// </summary>
    public class QuotesProvider : IQuotesProvider
    {
        public async Task<LastPriceDto> GetLastPriceAsync(string pair)
        {
            LastPriceResponse? response = await CexRequestor.GetLastPrice(pair.ToUpper());
            ValidateResponse(response, pair);
            return Mapping.Mapper.Map<LastPriceDto>(response);
        }

        public async Task<TickerDto> GetTickerAsync(string pair)
        {
            TickerResponse? response = await CexRequestor.GetTicker(pair.ToUpper());
            ValidateResponse(response, pair);
            return Mapping.Mapper.Map<TickerDto>(response);
        }

        protected void ValidateResponse(ICexResponse? response, string? pair)
        {
            if (response == null)
            {
                throw new EmptyResponseException();
            }
            if (!string.IsNullOrEmpty(response.Error))
            {
                if (response.Error.Contains("Invalid Symbols Pair"))
                {
                    throw new PairNotFoundException(pair);
                }
                throw new UnexpectedResponseException(response.Error);
            }
        }
    }
}
