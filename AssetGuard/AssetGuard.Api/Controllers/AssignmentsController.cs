using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssignmentsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignAsset(int assetId, int employeeId)
        {
            try
            {
                await _assetService.AssignAssetAsync(assetId, employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("return/{assetId}")]
        public async Task<IActionResult> ReturnAsset(int assetId)
        {
            await _assetService.ReturnAssetAsync(assetId);
            return Ok();
        }
    }
}
