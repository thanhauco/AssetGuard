using System;

namespace AssetGuard.Core.Entities
{
    public enum PurchaseRequestStatus
    {
        Draft,
        Submitted,
        Approved,
        Rejected,
        Ordered,
        Received,
        Cancelled
    }

    public class PurchaseRequest : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RequestedById { get; set; }
        public Employee RequestedBy { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal EstimatedUnitCost { get; set; }
        public decimal EstimatedTotalCost => Quantity * EstimatedUnitCost;
        public int? BudgetCodeId { get; set; }
        public BudgetCode BudgetCode { get; set; }
        public string Justification { get; set; }
        public PurchaseRequestStatus Status { get; set; } = PurchaseRequestStatus.Draft;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedById { get; set; }
        public string RejectionReason { get; set; }
    }
}
