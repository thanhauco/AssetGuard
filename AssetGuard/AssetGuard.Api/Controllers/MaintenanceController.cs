using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet("asset/{assetId}")]
        public async Task<ActionResult<IEnumerable<MaintenanceRecordDto>>> GetHistory(int assetId)
        {
            var history = await _maintenanceService.GetMaintenanceHistoryAsync(assetId);
            return Ok(history);
        }

        [HttpPost]
        public async Task<ActionResult<MaintenanceRecordDto>> Post([FromBody] CreateMaintenanceRecordDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try 
            {
                var createdRecord = await _maintenanceService.AddMaintenanceRecordAsync(dto);
                return Ok(createdRecord);
            }
            catch (System.ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
