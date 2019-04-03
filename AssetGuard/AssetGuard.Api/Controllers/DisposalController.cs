using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisposalController : ControllerBase
    {
        private readonly IDisposalService _disposalService;

        public DisposalController(IDisposalService disposalService)
        {
            _disposalService = disposalService;
        }

        [HttpPost("requests")]
        public async Task<IActionResult> CreateRequest([FromQuery] int assetId, [FromQuery] DisposalMethod method, [FromQuery] int requestedById, [FromQuery] string justification)
        {
            var result = await _disposalService.CreateRequestAsync(assetId, method, requestedById, justification);
            return Ok(result);
        }

        [HttpGet("requests/{id}")]
        public async Task<IActionResult> GetRequest(int id)
        {
            var result = await _disposalService.GetRequestByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("requests/pending")]
        public async Task<IActionResult> GetPendingRequests()
        {
            var result = await _disposalService.GetPendingRequestsAsync();
            return Ok(result);
        }

        [HttpPost("requests/{id}/approve")]
        public async Task<IActionResult> Approve(int id, [FromQuery] int approvedById)
        {
            await _disposalService.ApproveRequestAsync(id, approvedById);
            return Ok();
        }

        [HttpPost("requests/{id}/reject")]
        public async Task<IActionResult> Reject(int id, [FromQuery] int rejectedById, [FromQuery] string reason)
        {
            await _disposalService.RejectRequestAsync(id, rejectedById, reason);
            return Ok();
        }

        [HttpPost("requests/{id}/complete")]
        public async Task<IActionResult> Complete(int id, [FromQuery] decimal actualSalvageValue, [FromQuery] string recipientInfo)
        {
            await _disposalService.CompleteDisposalAsync(id, actualSalvageValue, recipientInfo);
            return Ok();
        }

        [HttpPost("certificates/{disposalRequestId}")]
        public async Task<IActionResult> GenerateCertificate(int disposalRequestId, [FromQuery] string issuedBy)
        {
            var result = await _disposalService.GenerateCertificateAsync(disposalRequestId, issuedBy);
            return Ok(result);
        }
    }
}
