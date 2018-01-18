using System;

namespace AssetGuard.Core.Entities
{
    public class DocumentVersion : BaseEntity
    {
        public int DocumentId { get; set; }
        public int VersionNumber { get; set; }
        public string StoragePath { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long SizeBytes { get; set; }
        public string UploadedBy { get; set; }
    }
}
