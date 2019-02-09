using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransfersController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        public async Task<IActionResult> InitiateTransfer([FromBody] CreateTransferDto dto)
        {
            var result = await _transferService.InitiateTransferAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _transferService.GetTransferByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("asset/{assetId}/history")]
        public async Task<IActionResult> GetHistory(int assetId)
        {
            var result = await _transferService.GetTransferHistoryForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var result = await _transferService.GetPendingTransfersAsync();
            return Ok(result);
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            await _transferService.CompleteTransferAsync(id);
            return Ok();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id, [FromQuery] string reason)
        {
            await _transferService.CancelTransferAsync(id, reason);
            return Ok();
        }

        [HttpGet("asset/{assetId}/report")]
        public async Task<IActionResult> GetMovementReport(int assetId)
        {
            var result = await _transferService.GetAssetMovementReportAsync(assetId);
            return Ok(result);
        }
    }
}
