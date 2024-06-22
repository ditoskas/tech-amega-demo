using Contracts.DatabaseServices;
using Entities.Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/instruments")]
    [ApiController]
    public class InstrumentsController : BaseApiController
    {
        public InstrumentsController(IDatabaseServiceManager dbServiceManager) : base(dbServiceManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetPairs()
        {
            var instruments = await _dbServiceManager.InstrumentPairService.GetAllInstrumentPairsAsync();
            return new ApiResult(instruments);
        }
    }
}
