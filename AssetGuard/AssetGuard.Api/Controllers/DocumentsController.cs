using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _documentService.GetAllDocumentsAsync());
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] DocumentUploadDto dto)
        {
            var user = User.Identity.IsAuthenticated ? User.Identity.Name : "Anonymous";
            var result = await _documentService.UploadAsync(dto, user);
            return Ok(result);
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var bytes = await _documentService.GetDocumentContentAsync(id, null);
            return File(bytes, "application/octet-stream", "download.bin");
        }
    }
}
