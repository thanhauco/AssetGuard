using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationsController : ControllerBase
    {
        private readonly IIntegrationService _integrationService;

        public IntegrationsController(IIntegrationService integrationService)
        {
            _integrationService = integrationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIntegration([FromBody] IntegrationConfig config)
        {
            var result = await _integrationService.CreateIntegrationAsync(config);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _integrationService.GetAllIntegrationsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _integrationService.GetIntegrationByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("{id}/enable")]
        public async Task<IActionResult> Enable(int id)
        {
            await _integrationService.EnableIntegrationAsync(id);
            return Ok();
        }

        [HttpPost("{id}/disable")]
        public async Task<IActionResult> Disable(int id)
        {
            await _integrationService.DisableIntegrationAsync(id);
            return Ok();
        }

        [HttpPost("webhooks")]
        public async Task<IActionResult> CreateWebhook([FromBody] WebhookSubscription subscription)
        {
            var result = await _integrationService.CreateWebhookAsync(subscription);
            return Ok(result);
        }

        [HttpGet("webhooks")]
        public async Task<IActionResult> GetActiveWebhooks()
        {
            var result = await _integrationService.GetActiveWebhooksAsync();
            return Ok(result);
        }

        [HttpPost("{id}/sync")]
        public async Task<IActionResult> StartSync(int id)
        {
            var result = await _integrationService.StartSyncJobAsync(id);
            return Ok(result);
        }

        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetJobStatus(int jobId)
        {
            var result = await _integrationService.GetSyncJobStatusAsync(jobId);
            return Ok(result);
        }
    }
}
