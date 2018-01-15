using System;

namespace AssetGuard.Core.Entities
{
    public class Issue : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IssuePriority Priority { get; set; }
        public IssueStatus Status { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public int? ReportedByUserId { get; set; } // Simplified, assuming user ID is int
    }

    public enum IssuePriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public enum IssueStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }
}
