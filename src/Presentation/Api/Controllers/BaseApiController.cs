using Contracts.DatabaseServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IDatabaseServiceManager _dbServiceManager;
        public BaseApiController(IDatabaseServiceManager dbServiceManager)
        {
            _dbServiceManager = dbServiceManager;
        }
    }
}
