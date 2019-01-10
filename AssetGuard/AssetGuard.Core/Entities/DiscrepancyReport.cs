using System;

namespace AssetGuard.Core.Entities
{
    public enum DiscrepancyType
    {
        Missing,
        LocationMismatch,
        ConditionChange,
        UnauthorizedAsset,
        DuplicateScan
    }

    public enum DiscrepancyResolution
    {
        Pending,
        Resolved,
        WriteOff,
        Ignored
    }

    public class DiscrepancyReport : BaseEntity
    {
        public int AuditSessionId { get; set; }
        public AuditSession AuditSession { get; set; }
        public int? AssetId { get; set; }
        public Asset Asset { get; set; }
        public DiscrepancyType Type { get; set; }
        public string Description { get; set; }
        public string ExpectedLocation { get; set; }
        public string ActualLocation { get; set; }
        public DiscrepancyResolution Resolution { get; set; } = DiscrepancyResolution.Pending;
        public string ResolutionNotes { get; set; }
        public int? ResolvedById { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }
}
