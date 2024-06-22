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

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _instrumentRepository = new Lazy<IIntrumentRepository>(() => new InstrumentRepository(_repositoryContext));
            _instrumentPairsRepository = new Lazy<IIntrumentPairRepository>(() => new InstrumentPairRepository(_repositoryContext));
        }

        public IIntrumentRepository Instrument => _instrumentRepository.Value;
        public IIntrumentPairRepository InstrumentPair => _instrumentPairsRepository.Value;


        public async Task SaveAsync () => await _repositoryContext.SaveChangesAsync();
    }
}
