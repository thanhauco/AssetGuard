using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Document : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual DocumentCategory Category { get; set; }
        
        public ICollection<DocumentVersion> Versions { get; set; }
    }
}
