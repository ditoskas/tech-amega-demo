using Contracts.Repositories;
using Entities.Models;

namespace Repository
{
    public class QuoteRepository : RepositoryBase<Quote>, IQuoteRepository
    {
        public QuoteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateQuote(Quote quote)
        {
            Create(quote);
        }
    }
}
