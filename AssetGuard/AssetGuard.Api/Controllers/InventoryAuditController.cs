using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryAuditController : ControllerBase
    {
        private readonly IInventoryAuditService _auditService;

        public InventoryAuditController(IInventoryAuditService auditService)
        {
            _auditService = auditService;
        }

        [HttpPost("sessions")]
        public async Task<IActionResult> CreateSession([FromBody] CreateAuditSessionDto dto)
        {
            var result = await _auditService.CreateSessionAsync(dto);
            return Ok(result);
        }

        [HttpGet("sessions/{id}")]
        public async Task<IActionResult> GetSession(int id)
        {
            var result = await _auditService.GetSessionByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("sessions/active")]
        public async Task<IActionResult> GetActiveSessions()
        {
            var result = await _auditService.GetActiveSessionsAsync();
            return Ok(result);
        }

        [HttpPost("sessions/{id}/start")]
        public async Task<IActionResult> StartSession(int id)
        {
            await _auditService.StartSessionAsync(id);
            return Ok();
        }

        [HttpPost("sessions/{id}/complete")]
        public async Task<IActionResult> CompleteSession(int id)
        {
            await _auditService.CompleteSessionAsync(id);
            return Ok();
        }

        [HttpPost("scans")]
        public async Task<IActionResult> RecordScan([FromBody] RecordScanDto dto)
        {
            var result = await _auditService.RecordScanAsync(dto);
            return Ok(result);
        }

        [HttpGet("sessions/{id}/scans")]
        public async Task<IActionResult> GetScans(int id)
        {
            var result = await _auditService.GetScansForSessionAsync(id);
            return Ok(result);
        }

        [HttpPost("discrepancies/resolve")]
        public async Task<IActionResult> ResolveDiscrepancy([FromBody] ResolveDiscrepancyDto dto)
        {
            await _auditService.ResolveDiscrepancyAsync(dto);
            return Ok();
        }

        [HttpGet("sessions/{id}/summary")]
        public async Task<IActionResult> GetSummary(int id)
        {
            var result = await _auditService.GetAuditSummaryAsync(id);
            return Ok(result);
        }
    }
}
