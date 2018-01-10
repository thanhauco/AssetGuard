using System;

namespace AssetGuard.Core.Entities
{
    public class ApprovalRequest : BaseEntity
    {
        public int WorkflowId { get; set; }
        public int CurrentStepId { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public int RequesterUserId { get; set; }
        public string RequestData { get; set; } // JSON details of request
    }
}
