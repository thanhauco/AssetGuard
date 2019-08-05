using System.Threading.Tasks;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainController : ControllerBase
    {
        private readonly IBlockchainService _s;
        public BlockchainController(IBlockchainService s) { _s = s; }

        [HttpPost("transactions")]
        public async Task<IActionResult> Record(int assetId, string action) 
            => Ok(await _s.RecordTransactionAsync(assetId, action, null));
    }
}
