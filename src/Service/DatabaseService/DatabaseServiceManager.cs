using AutoMapper;
using Contracts;
using Contracts.DatabaseServices;
using Contracts.Repositories;

namespace DatabaseService
{
    /// <summary>
    /// Main class which handles all the services for database operations
    /// </summary>
    public sealed class DatabaseServiceManager : IDatabaseServiceManager
    {
        private readonly Lazy<IInstrumentPairService> _instrumentPairService;
        private readonly Lazy<IQuoteService> _quoteService;

        public DatabaseServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _instrumentPairService = new Lazy<IInstrumentPairService>(() => new InstrumentPairService(repositoryManager, logger, mapper));
            _quoteService = new Lazy<IQuoteService>(() => new QuoteService(repositoryManager, logger, mapper));
        }

        public IInstrumentPairService InstrumentPairService => _instrumentPairService.Value;
        public IQuoteService QuoteService => _quoteService.Value;
    }
}
