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

        public DatabaseServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _instrumentPairService = new Lazy<IInstrumentPairService>(() => new InstrumentPairService(repositoryManager, logger, mapper));
        }

        public IInstrumentPairService InstrumentPairService => _instrumentPairService.Value;
    }
}
