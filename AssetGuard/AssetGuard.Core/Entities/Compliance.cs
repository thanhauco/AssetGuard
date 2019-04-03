using System;

namespace AssetGuard.Core.Entities
{
    public enum ComplianceStatus
    {
        Compliant,
        NonCompliant,
        PendingReview,
        Expired,
        NotApplicable
    }

    public class ComplianceRequirement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegulationType { get; set; }  // SOX, HIPAA, GDPR, ISO27001, PCI-DSS
        public string Framework { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int FrequencyDays { get; set; } = 365;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class ComplianceCheck : BaseEntity
    {
        public int ComplianceRequirementId { get; set; }
        public ComplianceRequirement Requirement { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime CheckDate { get; set; } = DateTime.UtcNow;
        public ComplianceStatus Status { get; set; }
        public int PerformedById { get; set; }
        public Employee PerformedBy { get; set; }
        public string Notes { get; set; }
        public string Evidence { get; set; }
        public DateTime? NextCheckDue { get; set; }
    }
}
