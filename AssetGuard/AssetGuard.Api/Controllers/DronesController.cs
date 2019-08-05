using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IDroneService _s;
        public DronesController(IDroneService s) { _s = s; }

        [HttpPost("flights")]
        public async Task<IActionResult> Schedule(DroneFlight f) => Ok(await _s.ScheduleFlightAsync(f));
    }
}
