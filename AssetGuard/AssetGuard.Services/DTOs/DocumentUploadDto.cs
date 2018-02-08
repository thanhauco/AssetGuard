using Microsoft.AspNetCore.Http;

namespace AssetGuard.Services.DTOs
{
    public class DocumentUploadDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
    }
}
