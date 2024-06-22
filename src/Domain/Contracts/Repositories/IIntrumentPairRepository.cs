using Entities.Models;

namespace Contracts.Repositories
{
    public interface IIntrumentPairRepository
    {
        public Task<IEnumerable<InstrumentPair>> GetAllInstrumentPairsAsync(bool trackChanges = false);
    }
}
