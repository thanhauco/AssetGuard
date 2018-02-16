using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        [HttpPost]
        public async Task<IActionResult> Report([FromBody] CreateIssueDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _issueService.ReportIssueAsync(dto);
            return Ok(result);
        }

        [HttpGet("open")]
        public async Task<IActionResult> GetOpen()
        {
            return Ok(await _issueService.GetOpenIssuesAsync());
        }

        [HttpPost("{id}/resolve")]
        public async Task<IActionResult> Resolve(int id)
        {
            await _issueService.ResolveIssueAsync(id);
            return Ok();
        }
    }
}
