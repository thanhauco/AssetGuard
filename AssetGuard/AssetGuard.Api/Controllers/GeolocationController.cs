using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IGeolocationService _geolocationService;

        public GeolocationController(IGeolocationService geolocationService)
        {
            _geolocationService = geolocationService;
        }

        [HttpPost("location")]
        public async Task<IActionResult> RecordLocation([FromQuery] int assetId, [FromQuery] double lat, [FromQuery] double lng, [FromQuery] string source, [FromQuery] string deviceId)
        {
            var result = await _geolocationService.RecordLocationAsync(assetId, lat, lng, source, deviceId);
            return Ok(result);
        }

        [HttpGet("location/{assetId}")]
        public async Task<IActionResult> GetCurrentLocation(int assetId)
        {
            var result = await _geolocationService.GetCurrentLocationAsync(assetId);
            return Ok(result);
        }

        [HttpGet("location/{assetId}/history")]
        public async Task<IActionResult> GetHistory(int assetId, [FromQuery] int limit = 50)
        {
            var result = await _geolocationService.GetLocationHistoryAsync(assetId, limit);
            return Ok(result);
        }

        [HttpPost("geofences")]
        public async Task<IActionResult> CreateGeoFence([FromBody] GeoFence fence)
        {
            var result = await _geolocationService.CreateGeoFenceAsync(fence);
            return Ok(result);
        }

        [HttpGet("geofences")]
        public async Task<IActionResult> GetActiveFences()
        {
            var result = await _geolocationService.GetActiveFencesAsync();
            return Ok(result);
        }

        [HttpGet("geofences/{fenceId}/check/{assetId}")]
        public async Task<IActionResult> CheckIfInFence(int assetId, int fenceId)
        {
            var result = await _geolocationService.IsAssetInFenceAsync(assetId, fenceId);
            return Ok(new { InFence = result });
        }

        [HttpGet("violations")]
        public async Task<IActionResult> GetViolations()
        {
            var result = await _geolocationService.GetUnacknowledgedViolationsAsync();
            return Ok(result);
        }
    }
}
