
namespace Contracts.Repositories
{
    public interface IRepositoryManager
    {
        IIntrumentPairRepository InstrumentPair { get; }
        IIntrumentRepository Instrument { get; }
        Task SaveAsync();
    }
}
