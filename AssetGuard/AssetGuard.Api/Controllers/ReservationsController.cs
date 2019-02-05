using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto dto)
        {
            var result = await _reservationService.CreateReservationAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _reservationService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("asset/{assetId}")]
        public async Task<IActionResult> GetForAsset(int assetId)
        {
            var result = await _reservationService.GetReservationsForAssetAsync(assetId);
            return Ok(result);
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var result = await _reservationService.GetPendingReservationsAsync();
            return Ok(result);
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(int id, [FromQuery] int approverId)
        {
            await _reservationService.ApproveReservationAsync(id, approverId);
            return Ok();
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> Reject(int id, [FromQuery] int approverId, [FromQuery] string reason)
        {
            await _reservationService.RejectReservationAsync(id, approverId, reason);
            return Ok();
        }

        [HttpGet("availability")]
        public async Task<IActionResult> CheckAvailability([FromQuery] int assetId, [FromQuery] System.DateTime start, [FromQuery] System.DateTime end)
        {
            var result = await _reservationService.IsAssetAvailableAsync(assetId, start, end);
            return Ok(new { Available = result });
        }
    }
}
