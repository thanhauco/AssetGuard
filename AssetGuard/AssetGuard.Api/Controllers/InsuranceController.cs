using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost("warranties")]
        public async Task<IActionResult> AddWarranty([FromBody] WarrantyDto dto)
        {
            var result = await _insuranceService.AddWarrantyAsync(dto);
            return Ok(result);
        }

        [HttpGet("warranties/{id}")]
        public async Task<IActionResult> GetWarranty(int id)
        {
            var result = await _insuranceService.GetWarrantyByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("warranties/asset/{assetId}")]
        public async Task<IActionResult> GetWarrantiesForAsset(int assetId)
        {
            var result = await _insuranceService.GetWarrantiesForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpGet("warranties/expiring")]
        public async Task<IActionResult> GetExpiringWarranties([FromQuery] int days = 30)
        {
            var result = await _insuranceService.GetExpiringWarrantiesAsync(days);
            return Ok(result);
        }

        [HttpPost("policies")]
        public async Task<IActionResult> AddPolicy([FromBody] InsurancePolicyDto dto)
        {
            var result = await _insuranceService.AddInsurancePolicyAsync(dto);
            return Ok(result);
        }

        [HttpGet("policies/{id}")]
        public async Task<IActionResult> GetPolicy(int id)
        {
            var result = await _insuranceService.GetInsurancePolicyByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("policies/asset/{assetId}")]
        public async Task<IActionResult> GetPoliciesForAsset(int assetId)
        {
            var result = await _insuranceService.GetPoliciesForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpGet("coverage/{assetId}")]
        public async Task<IActionResult> GetTotalCoverage(int assetId)
        {
            var result = await _insuranceService.CalculateTotalCoverageAsync(assetId);
            return Ok(new { TotalCoverage = result });
        }
    }
}
