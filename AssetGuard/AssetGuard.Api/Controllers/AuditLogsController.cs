using System;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet("entity/{entityType}/{entityId}")]
        public async Task<IActionResult> GetLogsForEntity(string entityType, int entityId)
        {
            var result = await _auditLogService.GetLogsForEntityAsync(entityType, entityId);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetLogsForUser(int userId)
        {
            var result = await _auditLogService.GetLogsForUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecentLogs([FromQuery] int count = 100)
        {
            var result = await _auditLogService.GetRecentLogsAsync(count);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchLogs([FromQuery] string searchTerm, [FromQuery] AuditAction? action, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var result = await _auditLogService.SearchLogsAsync(searchTerm, action, fromDate, toDate);
            return Ok(result);
        }
    }
}
