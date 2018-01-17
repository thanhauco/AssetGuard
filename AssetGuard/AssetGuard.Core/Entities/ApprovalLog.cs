using System;

namespace AssetGuard.Core.Entities
{
    public class ApprovalLog : BaseEntity
    {
        public int ApprovalRequestId { get; set; }
        public int ApproverUserId { get; set; }
        public string Action { get; set; } // Approve, Reject
        public string Comments { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
