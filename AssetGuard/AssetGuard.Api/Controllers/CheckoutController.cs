using System.Threading.Tasks;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromQuery] int assetId, [FromQuery] int employeeId, [FromQuery] string deviceId, [FromQuery] string condition)
        {
            var result = await _checkoutService.CheckoutAssetAsync(assetId, employeeId, deviceId, condition);
            return Ok(result);
        }

        [HttpPost("return/{sessionId}")]
        public async Task<IActionResult> Return(int sessionId, [FromQuery] string condition, [FromQuery] string notes)
        {
            var result = await _checkoutService.ReturnAssetAsync(sessionId, condition, notes);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSession(int id)
        {
            var result = await _checkoutService.GetSessionByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var result = await _checkoutService.GetActiveCheckoutsAsync();
            return Ok(result);
        }

        [HttpGet("overdue")]
        public async Task<IActionResult> GetOverdue()
        {
            var result = await _checkoutService.GetOverdueCheckoutsAsync();
            return Ok(result);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetForEmployee(int employeeId)
        {
            var result = await _checkoutService.GetCheckoutsForEmployeeAsync(employeeId);
            return Ok(result);
        }

        [HttpGet("asset/{assetId}/history")]
        public async Task<IActionResult> GetHistory(int assetId)
        {
            var result = await _checkoutService.GetCheckoutHistoryForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpPost("devices/register")]
        public async Task<IActionResult> RegisterDevice([FromQuery] string deviceId, [FromQuery] string name, [FromQuery] string platform, [FromQuery] int? assignedToId)
        {
            var result = await _checkoutService.RegisterDeviceAsync(deviceId, name, platform, assignedToId);
            return Ok(result);
        }

        [HttpPost("sync/{deviceId}")]
        public async Task<IActionResult> ProcessSync(string deviceId)
        {
            await _checkoutService.ProcessOfflineQueueAsync(deviceId);
            return Ok();
        }
    }
}
