using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {
        private readonly IWorkOrderService _workOrderService;

        public WorkOrdersController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkOrder workOrder)
        {
            var result = await _workOrderService.CreateWorkOrderAsync(workOrder);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _workOrderService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("asset/{assetId}")]
        public async Task<IActionResult> GetForAsset(int assetId)
        {
            var result = await _workOrderService.GetByAssetIdAsync(assetId);
            return Ok(result);
        }

        [HttpPost("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] WorkOrderStatus status, [FromQuery] int? userId)
        {
            await _workOrderService.UpdateStatusAsync(id, status, userId);
            return Ok();
        }

        [HttpPost("{id}/tasks")]
        public async Task<IActionResult> AddTask(int id, [FromQuery] string description, [FromQuery] decimal estimate)
        {
            var result = await _workOrderService.AddTaskAsync(id, description, estimate);
            return Ok(result);
        }
    }
}
