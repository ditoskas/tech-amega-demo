using Entities.Models;

namespace Contracts.Repositories
{
    public interface IQuoteRepository
    {
        void CreateQuote(Quote quote);
    }
}
