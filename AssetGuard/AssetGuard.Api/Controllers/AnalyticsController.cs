using System.Threading.Tasks;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpPost("forecast/{assetId}")]
        public async Task<IActionResult> GenerateForecast(int assetId)
        {
            var result = await _analyticsService.GenerateForecastAsync(assetId);
            return Ok(result);
        }

        [HttpGet("forecast/category/{categoryId}")]
        public async Task<IActionResult> GetCategoryForecasts(int categoryId)
        {
            var result = await _analyticsService.GetForecastsForCategoryAsync(categoryId);
            return Ok(result);
        }

        [HttpPost("utilization/{assetId}")]
        public async Task<IActionResult> CalculateUtilization(int assetId, [FromQuery] int periodDays = 30)
        {
            var result = await _analyticsService.CalculateUtilizationAsync(assetId, periodDays);
            return Ok(result);
        }

        [HttpGet("utilization/low")]
        public async Task<IActionResult> GetLowUtilization([FromQuery] decimal threshold = 20)
        {
            var result = await _analyticsService.GetLowUtilizationAssetsAsync(threshold);
            return Ok(result);
        }

        [HttpPost("projections/{fiscalYear}")]
        public async Task<IActionResult> GenerateProjection(int fiscalYear, [FromQuery] int? categoryId)
        {
            var result = await _analyticsService.GenerateCostProjectionAsync(fiscalYear, categoryId);
            return Ok(result);
        }

        [HttpGet("replacement-due")]
        public async Task<IActionResult> GetReplacementDue([FromQuery] int monthsAhead = 12)
        {
            var result = await _analyticsService.GetAssetsNeedingReplacementAsync(monthsAhead);
            return Ok(result);
        }

        [HttpGet("maintenance-due")]
        public async Task<IActionResult> GetMaintenanceDue([FromQuery] int daysAhead = 30)
        {
            var result = await _analyticsService.GetAssetsNeedingMaintenanceAsync(daysAhead);
            return Ok(result);
        }
    }
}
