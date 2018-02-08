using System;

namespace AssetGuard.Services.DTOs
{
    public class DocumentMetadataDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int LatestVersion { get; set; }
        public DateTime LastModified { get; set; }
    }
}
