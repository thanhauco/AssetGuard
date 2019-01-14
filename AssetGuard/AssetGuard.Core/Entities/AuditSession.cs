using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public enum AuditSessionStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }

    public class AuditSession : BaseEntity
    {
        public string Name { get; set; }
        public int? SiteId { get; set; }
        public Site Site { get; set; }
        public int? BuildingId { get; set; }
        public Building Building { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public AuditSessionStatus Status { get; set; } = AuditSessionStatus.Scheduled;
        public int ConductedById { get; set; }
        public Employee ConductedBy { get; set; }
        public string Notes { get; set; }
        
        public ICollection<AuditScan> Scans { get; set; } = new List<AuditScan>();
        public ICollection<DiscrepancyReport> Discrepancies { get; set; } = new List<DiscrepancyReport>();
        
        public int TotalAssetsExpected { get; set; }
        public int TotalAssetsScanned { get; set; }
    }
}
