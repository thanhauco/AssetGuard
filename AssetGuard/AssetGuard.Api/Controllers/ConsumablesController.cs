using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablesController : ControllerBase
    {
        private readonly IConsumableService _consumableService;

        public ConsumablesController(IConsumableService consumableService)
        {
            _consumableService = consumableService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Consumable consumable)
        {
            var result = await _consumableService.CreateConsumableAsync(consumable);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _consumableService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _consumableService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStock()
        {
            var result = await _consumableService.GetLowStockAsync();
            return Ok(result);
        }

        [HttpPost("{id}/add-stock")]
        public async Task<IActionResult> AddStock(int id, [FromQuery] int quantity, [FromQuery] string reason, [FromQuery] int performedById)
        {
            var result = await _consumableService.AddStockAsync(id, quantity, reason, performedById);
            return Ok(result);
        }

        [HttpPost("{id}/remove-stock")]
        public async Task<IActionResult> RemoveStock(int id, [FromQuery] int quantity, [FromQuery] string reason, [FromQuery] int performedById)
        {
            var result = await _consumableService.RemoveStockAsync(id, quantity, reason, performedById);
            return Ok(result);
        }

        [HttpGet("{id}/movements")]
        public async Task<IActionResult> GetMovements(int id)
        {
            var result = await _consumableService.GetMovementHistoryAsync(id);
            return Ok(result);
        }

        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlerts()
        {
            var result = await _consumableService.GetActiveAlertsAsync();
            return Ok(result);
        }
    }
}
