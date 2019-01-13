using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagGenerationService _tagService;

        public TagsController(ITagGenerationService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateTag([FromBody] GenerateTagDto dto)
        {
            var result = await _tagService.GenerateTagAsync(dto);
            return Ok(result);
        }

        [HttpPost("generate/batch")]
        public async Task<IActionResult> GenerateBatch([FromBody] IEnumerable<int> assetIds, [FromQuery] int? templateId)
        {
            var result = await _tagService.GenerateBatchTagsAsync(assetIds, templateId);
            return Ok(result);
        }

        [HttpPost("templates")]
        public async Task<IActionResult> CreateTemplate([FromBody] LabelTemplateDto dto)
        {
            var result = await _tagService.CreateTemplateAsync(dto);
            return Ok(result);
        }

        [HttpGet("templates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            var result = await _tagService.GetAllTemplatesAsync();
            return Ok(result);
        }

        [HttpGet("templates/{id}")]
        public async Task<IActionResult> GetTemplate(int id)
        {
            var result = await _tagService.GetTemplateByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("templates/{id}/default")]
        public async Task<IActionResult> SetDefault(int id)
        {
            await _tagService.SetDefaultTemplateAsync(id);
            return Ok();
        }
    }
}
