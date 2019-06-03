using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        private readonly IGlobalService _globalService;

        public GlobalController(IGlobalService globalService)
        {
            _globalService = globalService;
        }

        [HttpPost("currency/rate")]
        public async Task<IActionResult> UpdateRate([FromQuery] string code, [FromQuery] decimal rate)
        {
            var result = await _globalService.UpdateExchangeRateAsync(code, rate);
            return Ok(result);
        }

        [HttpGet("currency/convert")]
        public async Task<IActionResult> Convert([FromQuery] decimal amount, [FromQuery] string from, [FromQuery] string to)
        {
            var result = await _globalService.ConvertCurrencyAsync(amount, from, to);
            return Ok(new { ConvertedAmount = result });
        }

        [HttpPost("regions")]
        public async Task<IActionResult> CreateRegion([FromBody] Region region)
        {
            var result = await _globalService.CreateRegionAsync(region);
            return Ok(result);
        }

        [HttpPost("tax-rules")]
        public async Task<IActionResult> CreateTaxRule([FromBody] TaxRule rule)
        {
            var result = await _globalService.CreateTaxRuleAsync(rule);
            return Ok(result);
        }
    }
}
