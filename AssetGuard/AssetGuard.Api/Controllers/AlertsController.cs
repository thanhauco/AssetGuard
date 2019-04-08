using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpPost("rules")]
        public async Task<IActionResult> CreateRule([FromBody] AlertRule rule)
        {
            var result = await _alertService.CreateRuleAsync(rule);
            return Ok(result);
        }

        [HttpGet("rules")]
        public async Task<IActionResult> GetActiveRules()
        {
            var result = await _alertService.GetActiveRulesAsync();
            return Ok(result);
        }

        [HttpPost("rules/{id}/enable")]
        public async Task<IActionResult> EnableRule(int id)
        {
            await _alertService.EnableRuleAsync(id);
            return Ok();
        }

        [HttpPost("rules/{id}/disable")]
        public async Task<IActionResult> DisableRule(int id)
        {
            await _alertService.DisableRuleAsync(id);
            return Ok();
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnread()
        {
            var result = await _alertService.GetUnreadAlertsAsync();
            return Ok(result);
        }

        [HttpGet("asset/{assetId}")]
        public async Task<IActionResult> GetForAsset(int assetId)
        {
            var result = await _alertService.GetAlertsForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpPost("{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _alertService.MarkAsReadAsync(id);
            return Ok();
        }

        [HttpPost("{id}/dismiss")]
        public async Task<IActionResult> Dismiss(int id, [FromQuery] int dismissedById)
        {
            await _alertService.DismissAlertAsync(id, dismissedById);
            return Ok();
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessScheduled()
        {
            await _alertService.ProcessScheduledAlertsAsync();
            return Ok();
        }
    }
}
