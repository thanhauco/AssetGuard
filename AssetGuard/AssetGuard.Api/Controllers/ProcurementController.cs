using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : ControllerBase
    {
        private readonly IProcurementService _procurementService;

        public ProcurementController(IProcurementService procurementService)
        {
            _procurementService = procurementService;
        }

        [HttpPost("requests")]
        public async Task<IActionResult> CreateRequest([FromBody] PurchaseRequestDto dto)
        {
            var result = await _procurementService.CreateRequestAsync(dto);
            return Ok(result);
        }

        [HttpGet("requests/{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            var result = await _procurementService.GetRequestByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("requests/pending")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var result = await _procurementService.GetPendingRequestsAsync();
            return Ok(result);
        }

        [HttpPost("requests/{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromQuery] int approverId)
        {
            await _procurementService.ApproveRequestAsync(id, approverId);
            return Ok();
        }

        [HttpPost("requests/{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id, [FromQuery] int approverId, [FromQuery] string reason)
        {
            await _procurementService.RejectRequestAsync(id, approverId, reason);
            return Ok();
        }

        [HttpPost("quotes")]
        public async Task<IActionResult> AddQuote([FromBody] QuoteDto dto)
        {
            var result = await _procurementService.AddQuoteAsync(dto);
            return Ok(result);
        }

        [HttpGet("requests/{requestId}/quotes")]
        public async Task<IActionResult> GetQuotes(int requestId)
        {
            var result = await _procurementService.GetQuotesForRequestAsync(requestId);
            return Ok(result);
        }

        [HttpPost("quotes/{id}/select")]
        public async Task<IActionResult> SelectQuote(int id)
        {
            await _procurementService.SelectQuoteAsync(id);
            return Ok();
        }

        [HttpPost("orders")]
        public async Task<IActionResult> CreateOrder([FromBody] PurchaseOrderDto dto)
        {
            var result = await _procurementService.CreateOrderAsync(dto);
            return Ok(result);
        }

        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var result = await _procurementService.GetOrderByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("orders/{id}/receive")]
        public async Task<IActionResult> ReceiveOrder(int id, [FromBody] IEnumerable<int> assetIds)
        {
            await _procurementService.MarkOrderReceivedAsync(id, assetIds);
            return Ok();
        }
    }
}
