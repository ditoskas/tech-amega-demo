using Contracts;
using Contracts.DatabaseServices;
using Contracts.DataTransferObjects;
using Entities.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/quotes/")]
    [ApiController]
    public class QuotesController : BaseApiController
    {
        protected readonly IQuotesProvider _quotesProvider;
        public QuotesController(IDatabaseServiceManager dbServiceManager, IQuotesProvider quotesProvider) : base(dbServiceManager)
        {
            _quotesProvider = quotesProvider;
        }

        [HttpGet("{pair}", Name = "GetRate")]
        public async Task<IActionResult> GetRate(string pair)
        {
            //LastPriceDto lastPrice = await _quotesProvider.GetLastPriceAsync(pair);
            //return new ApiResult(lastPrice);

            /**
             * The below code is a workaround to get the last price of a pair
             * for some reason that i dont know the Cex API is not returning the last price correctly
             * it returns the same value, also on the ticker API response the last price is not correct 
             * as well, so i decided to calculate the last price based on the bid and ask values
             */

            TickerDto ticker = await _quotesProvider.GetTickerAsync(pair);
            decimal lastPrice = (ticker.Bid + ticker.Ask) / 2;
            string[] instruments = pair.Split('-');
            LastPriceDto lastPriceDto = new LastPriceDto
            {
                BaseCurrency = instruments[0],
                NonBaseCurrency = instruments[1],
                LastPrice = lastPrice.ToString(),
            };
            return new ApiResult(lastPriceDto);
        }
    }
}
