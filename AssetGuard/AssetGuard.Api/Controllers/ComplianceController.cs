using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceController : ControllerBase
    {
        private readonly IComplianceService _complianceService;

        public ComplianceController(IComplianceService complianceService)
        {
            _complianceService = complianceService;
        }

        [HttpPost("requirements")]
        public async Task<IActionResult> CreateRequirement([FromBody] ComplianceRequirement requirement)
        {
            var result = await _complianceService.CreateRequirementAsync(requirement);
            return Ok(result);
        }

        [HttpGet("requirements")]
        public async Task<IActionResult> GetActiveRequirements()
        {
            var result = await _complianceService.GetActiveRequirementsAsync();
            return Ok(result);
        }

        [HttpPost("checks")]
        public async Task<IActionResult> PerformCheck([FromQuery] int requirementId, [FromQuery] int assetId, [FromQuery] ComplianceStatus status, [FromQuery] int performedById, [FromQuery] string notes)
        {
            var result = await _complianceService.PerformCheckAsync(requirementId, assetId, status, performedById, notes);
            return Ok(result);
        }

        [HttpGet("checks/asset/{assetId}")]
        public async Task<IActionResult> GetChecksForAsset(int assetId)
        {
            var result = await _complianceService.GetChecksForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpGet("checks/pending")]
        public async Task<IActionResult> GetPendingChecks()
        {
            var result = await _complianceService.GetPendingChecksAsync();
            return Ok(result);
        }

        [HttpGet("assets/non-compliant")]
        public async Task<IActionResult> GetNonCompliantAssets()
        {
            var result = await _complianceService.GetNonCompliantAssetsAsync();
            return Ok(result);
        }
    }
}
