using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifecycleController : ControllerBase
    {
        private readonly ILifecycleService _lifecycleService;

        public LifecycleController(ILifecycleService lifecycleService)
        {
            _lifecycleService = lifecycleService;
        }

        [HttpPost("transition")]
        public async Task<IActionResult> TransitionStage([FromQuery] int assetId, [FromQuery] LifecycleStage stage, [FromQuery] int changedById, [FromQuery] string reason)
        {
            var result = await _lifecycleService.TransitionStageAsync(assetId, stage, changedById, reason);
            return Ok(result);
        }

        [HttpGet("history/{assetId}")]
        public async Task<IActionResult> GetHistory(int assetId)
        {
            var result = await _lifecycleService.GetLifecycleHistoryAsync(assetId);
            return Ok(result);
        }

        [HttpGet("current/{assetId}")]
        public async Task<IActionResult> GetCurrentStage(int assetId)
        {
            var result = await _lifecycleService.GetCurrentStageAsync(assetId);
            return Ok(new { Stage = result.ToString() });
        }

        [HttpPost("policies")]
        public async Task<IActionResult> CreatePolicy([FromBody] LifecyclePolicy policy)
        {
            var result = await _lifecycleService.CreatePolicyAsync(policy);
            return Ok(result);
        }

        [HttpGet("end-of-life")]
        public async Task<IActionResult> GetAssetsAtEndOfLife()
        {
            var result = await _lifecycleService.GetAssetsAtEndOfLifeAsync();
            return Ok(result);
        }
    }
}
