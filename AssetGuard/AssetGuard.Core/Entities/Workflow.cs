using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Workflow : BaseEntity
    {
        public string Name { get; set; } // e.g., "AssetPurchase", "AssetDisposal"
        public string Description { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<ApprovalStep> Steps { get; set; }
    }
}
