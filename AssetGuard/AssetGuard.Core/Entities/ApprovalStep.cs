namespace AssetGuard.Core.Entities
{
    public class ApprovalStep : BaseEntity
    {
        public int WorkflowId { get; set; }
        public int SequenceOrder { get; set; }
        public string ApproverRole { get; set; } // e.g., "Manager", "Finance"
        public int? ApproverUserId { get; set; } // specific user override
    }
}
