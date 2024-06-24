using Contracts.DatabaseServices;
using Contracts.Repositories;

namespace Repository
{
    /// <summary>
    /// Handle all repositories, main class to access the database
    /// </summary>
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IIntrumentRepository> _instrumentRepository;
        private readonly Lazy<IIntrumentPairRepository> _instrumentPairsRepository;
        private readonly Lazy<IQuoteRepository> _quoteRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _instrumentRepository = new Lazy<IIntrumentRepository>(() => new InstrumentRepository(_repositoryContext));
            _instrumentPairsRepository = new Lazy<IIntrumentPairRepository>(() => new InstrumentPairRepository(_repositoryContext));
            _quoteRepository = new Lazy<IQuoteRepository>(() => new QuoteRepository(_repositoryContext));
        }

        public IIntrumentRepository Instrument => _instrumentRepository.Value;
        public IIntrumentPairRepository InstrumentPair => _instrumentPairsRepository.Value;

        public IQuoteRepository Quote => _quoteRepository.Value;

        public async Task SaveAsync () => await _repositoryContext.SaveChangesAsync();
    }
}
