using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<DocumentMetadataDto> UploadAsync(DocumentUploadDto dto, string uploader);
        Task<IEnumerable<DocumentMetadataDto>> GetAllDocumentsAsync();
        Task<byte[]> GetDocumentContentAsync(int documentId, int? version);
    }
}
