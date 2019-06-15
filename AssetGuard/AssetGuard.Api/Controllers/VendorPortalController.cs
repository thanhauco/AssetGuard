using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorPortalController : ControllerBase
    {
        private readonly IVendorPortalService _vendorService;

        public VendorPortalController(IVendorPortalService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost("rfp")]
        public async Task<IActionResult> CreateRfp([FromBody] RequestForProposal rfp)
        {
            var result = await _vendorService.CreateRfpAsync(rfp);
            return Ok(result);
        }

        [HttpGet("rfp/open")]
        public async Task<IActionResult> GetOpenRfps()
        {
            var result = await _vendorService.GetOpenRfpsAsync();
            return Ok(result);
        }

        [HttpPost("rfp/{id}/bid")]
        public async Task<IActionResult> SubmitBid(int id, [FromQuery] int vendorId, [FromQuery] decimal amount, [FromQuery] string url)
        {
            var result = await _vendorService.SubmitBidAsync(id, vendorId, amount, url);
            return Ok(result);
        }

        [HttpPost("rfp/{id}/award")]
        public async Task<IActionResult> AwardBid(int id, [FromQuery] int bidId, [FromQuery] string notes)
        {
            await _vendorService.AwardBidAsync(id, bidId, notes);
            return Ok();
        }
    }
}
