using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldsController : ControllerBase
    {
        private readonly ICustomFieldService _customFieldService;

        public CustomFieldsController(ICustomFieldService customFieldService)
        {
            _customFieldService = customFieldService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateField([FromBody] CustomField field)
        {
            var result = await _customFieldService.CreateFieldAsync(field);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetField(int id)
        {
            var result = await _customFieldService.GetFieldByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetFieldsForCategory(int categoryId)
        {
            var result = await _customFieldService.GetFieldsForCategoryAsync(categoryId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            await _customFieldService.DeleteFieldAsync(id);
            return Ok();
        }

        [HttpPost("values")]
        public async Task<IActionResult> SetValue([FromQuery] int assetId, [FromQuery] int fieldId, [FromQuery] string value)
        {
            var result = await _customFieldService.SetFieldValueAsync(assetId, fieldId, value);
            return Ok(result);
        }

        [HttpGet("values/asset/{assetId}")]
        public async Task<IActionResult> GetValuesForAsset(int assetId)
        {
            var result = await _customFieldService.GetValuesForAssetAsync(assetId);
            return Ok(result);
        }
    }
}
