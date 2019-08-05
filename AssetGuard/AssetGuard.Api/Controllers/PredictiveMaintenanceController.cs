using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictiveMaintenanceController : ControllerBase
    {
        private readonly IPredictiveMaintenanceService _s;
        public PredictiveMaintenanceController(IPredictiveMaintenanceService s) { _s = s; }

        [HttpPost("models")]
        public async Task<IActionResult> Train(string name, string url) => Ok(await _s.TrainModelAsync(name, url));
    }
}
