using Contracts.Repositories;
using Entities.Models;

namespace Repository
{
    public class InstrumentRepository : RepositoryBase<Instrument>, IIntrumentRepository
    {
        public InstrumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
