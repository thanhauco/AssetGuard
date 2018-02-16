using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicensesController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicensesController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _licenseService.GetAllLicensesAsync());
        }

        [HttpPost("{id}/allocate")]
        public async Task<IActionResult> Allocate(int id, [FromQuery] int? assetId, [FromQuery] int? userId)
        {
            await _licenseService.AllocateLicenseAsync(id, assetId, userId);
            return Ok();
        }
    }
}
