using AutoMapper;
using Contracts;
using Contracts.DatabaseServices;
using Contracts.DataTransferObjects;
using Contracts.Repositories;
using Entities.Models;

namespace DatabaseService
{
    public class QuoteService : BaseService, IQuoteService
    {
        public QuoteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        public async Task<QuoteDto> CreateQuoteAsync(QuoteForCreationDto quote)
        {
            var quoteEntity = _mapper.Map<Quote>(quote);
            _repository.Quote.CreateQuote(quoteEntity);

            await _repository.SaveAsync();

            return _mapper.Map<QuoteDto>(quoteEntity);
        }
    }
}
