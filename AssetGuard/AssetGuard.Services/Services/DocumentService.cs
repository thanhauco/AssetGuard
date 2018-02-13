using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DocumentMetadataDto> UploadAsync(DocumentUploadDto dto, string uploader)
        {
            // Create Document
            var doc = new Document
            {
                Title = dto.Title,
                Description = dto.Description,
                CategoryId = dto.CategoryId
            };
            await _unitOfWork.Repository<Document>().AddAsync(doc);
            
            // In real app, save stream to disk/S3 and get path
            var fakePath = $"/storage/{Guid.NewGuid()}/{dto.File.FileName}";
            
            var version = new DocumentVersion
            {
                DocumentId = doc.Id, // Will be set after save? No, EF requires graph or order.
                // Assuming EF handles graph or we need to save doc first? 
                // Let's rely on SaveChanges for ID generation if we add to collection, 
                // but simpler to save doc then add version.
                
                VersionNumber = 1,
                StoragePath = fakePath,
                FileName = dto.File.FileName,
                ContentType = dto.File.ContentType,
                SizeBytes = dto.File.Length,
                UploadedBy = uploader
            };
            
            // Simplified: Save doc first
            await _unitOfWork.CompleteAsync();
            
            version.DocumentId = doc.Id;
            await _unitOfWork.Repository<DocumentVersion>().AddAsync(version);
            await _unitOfWork.CompleteAsync();

            return new DocumentMetadataDto
            {
                Id = doc.Id,
                Title = doc.Title,
                Category = "Unknown", // Needs include
                LatestVersion = 1,
                LastModified = DateTime.UtcNow
            };
        }

        public async Task<IEnumerable<DocumentMetadataDto>> GetAllDocumentsAsync()
        {
            var docs = await _unitOfWork.Repository<Document>().GetAllAsync();
            return docs.Select(d => new DocumentMetadataDto
            {
                Id = d.Id,
                Title = d.Title,
                LatestVersion = 0, // Needs loading versions
                LastModified = d.CreatedAt
            });
        }

        public async Task<byte[]> GetDocumentContentAsync(int documentId, int? version)
        {
            return new byte[0]; // Placeholder
        }
    }
}
