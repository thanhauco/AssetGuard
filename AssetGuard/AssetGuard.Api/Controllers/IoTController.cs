using System;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTController : ControllerBase
    {
        private readonly IIoTService _iotService;

        public IoTController(IIoTService iotService)
        {
            _iotService = iotService;
        }

        [HttpPost("gateways")]
        public async Task<IActionResult> RegisterGateway([FromBody] IoTGateway gateway)
        {
            var result = await _iotService.RegisterGatewayAsync(gateway);
            return Ok(result);
        }

        [HttpPost("sensors")]
        public async Task<IActionResult> RegisterSensor([FromBody] IoTSensor sensor)
        {
            var result = await _iotService.RegisterSensorAsync(sensor);
            return Ok(result);
        }

        [HttpPost("readings")]
        public async Task<IActionResult> PostReading([FromQuery] string sensorId, [FromQuery] double value)
        {
            await _iotService.ProcessReadingAsync(sensorId, value, DateTime.UtcNow);
            return Ok();
        }

        [HttpGet("sensors/{id}/readings")]
        public async Task<IActionResult> GetReadings(int id, [FromQuery] int limit = 100)
        {
            var result = await _iotService.GetReadingsAsync(id, limit);
            return Ok(result);
        }

        [HttpGet("anomalies/asset/{assetId}")]
        public async Task<IActionResult> GetAnomalies(int assetId)
        {
            var result = await _iotService.DetectAnomaliesAsync(assetId);
            return Ok(result);
        }
    }
}
