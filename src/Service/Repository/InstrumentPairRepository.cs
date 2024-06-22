using Contracts.Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    /// <summary>
    /// Repository to handle CRUD operations on the InstrumentPair table
    /// </summary>
    public class InstrumentPairRepository : RepositoryBase<InstrumentPair>, IIntrumentPairRepository
    {
        public InstrumentPairRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<InstrumentPair>> GetAllInstrumentPairsAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges)
                            .Include(i => i.BaseInstrument)
                            .Include(i => i.NonBaseInstrument)
                            .ToListAsync();
        }
    }
}
