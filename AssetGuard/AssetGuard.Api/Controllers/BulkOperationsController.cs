using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkOperationsController : ControllerBase
    {
        private readonly IBulkOperationService _bulkService;

        public BulkOperationsController(IBulkOperationService bulkService)
        {
            _bulkService = bulkService;
        }

        [HttpPost("update")]
        public async Task<IActionResult> BulkUpdate([FromQuery] string inputFileUrl, [FromQuery] int initiatedById)
        {
            var result = await _bulkService.StartBulkUpdateAsync(inputFileUrl, initiatedById);
            return Ok(result);
        }

        [HttpPost("retire")]
        public async Task<IActionResult> BulkRetire([FromBody] IEnumerable<int> assetIds, [FromQuery] int initiatedById)
        {
            var result = await _bulkService.StartBulkRetireAsync(assetIds, initiatedById);
            return Ok(result);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> BulkTransfer([FromBody] IEnumerable<int> assetIds, [FromQuery] int toRoomId, [FromQuery] int initiatedById)
        {
            var result = await _bulkService.StartBulkTransferAsync(assetIds, toRoomId, initiatedById);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var result = await _bulkService.GetOperationStatusAsync(id);
            return Ok(result);
        }

        [HttpGet("recent")]
        public async Task<IActionResult> GetRecent([FromQuery] int count = 10)
        {
            var result = await _bulkService.GetRecentOperationsAsync(count);
            return Ok(result);
        }

        [HttpPost("export")]
        public async Task<IActionResult> Export([FromBody] IEnumerable<int> assetIds, [FromQuery] string format = "csv")
        {
            var result = await _bulkService.ExportAssetsAsync(assetIds, format);
            return Ok(new { Data = result });
        }

        [HttpPost("clone/{sourceAssetId}")]
        public async Task<IActionResult> CloneAsset(int sourceAssetId, [FromQuery] string newSerialNumber)
        {
            var result = await _bulkService.CloneAssetAsync(sourceAssetId, newSerialNumber);
            return Ok(result);
        }

        [HttpPost("clone/{sourceAssetId}/batch")]
        public async Task<IActionResult> CloneBatch(int sourceAssetId, [FromQuery] int count, [FromQuery] string serialPrefix)
        {
            var result = await _bulkService.CloneAssetBatchAsync(sourceAssetId, count, serialPrefix);
            return Ok(result);
        }
    }
}
