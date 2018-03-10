using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;

        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult<DashboardMetricsDto>> GetDashboard()
        {
            return Ok(await _reportingService.GetDashboardMetricsAsync());
        }

        [HttpGet("definitions")]
        public async Task<IActionResult> GetDefinitions()
        {
            return Ok(await _reportingService.GetReportDefinitionsAsync());
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] ReportRequestDto request)
        {
            var fileContent = await _reportingService.GenerateReportAsync(request);
            var contentType = request.Format == "PDF" ? "application/pdf" : "text/csv";
            return File(fileContent, contentType, $"report.{request.Format.ToLower()}");
        }
    }
}
