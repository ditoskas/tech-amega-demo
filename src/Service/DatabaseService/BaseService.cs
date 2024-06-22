using AutoMapper;
using Contracts;
using Contracts.Repositories;

namespace DatabaseService
{
    public class BaseService
    {
        protected readonly IRepositoryManager _repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        public BaseService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
