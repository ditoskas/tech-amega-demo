using AutoMapper;
using Contracts;
using Contracts.DatabaseServices;
using Contracts.DataTransferObjects;
using Contracts.Repositories;

namespace DatabaseService
{
    public class InstrumentPairService : BaseService, IInstrumentPairService
    {
        public InstrumentPairService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        public async Task<IEnumerable<InstrumentPairDto>> GetAllInstrumentPairsAsync(bool trackChanges = false)
        {
            var instrumentPairs = await _repository.InstrumentPair.GetAllInstrumentPairsAsync(trackChanges);
            return _mapper.Map<IEnumerable<InstrumentPairDto>>(instrumentPairs);
        }
    }
}
