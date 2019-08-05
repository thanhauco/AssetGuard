using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitalTwinsController : ControllerBase
    {
        private readonly IDigitalTwinService _s;
        public DigitalTwinsController(IDigitalTwinService s) { _s = s; }

        [HttpPost]
        public async Task<IActionResult> Create(DigitalTwin t) => Ok(await _s.CreateTwinAsync(t));
    }
}
