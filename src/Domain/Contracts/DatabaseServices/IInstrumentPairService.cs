using Contracts.DataTransferObjects;

namespace Contracts.DatabaseServices
{
    public interface IInstrumentPairService
    {
        Task<IEnumerable<InstrumentPairDto>> GetAllInstrumentPairsAsync(bool trackChanges = false);
    }
}
