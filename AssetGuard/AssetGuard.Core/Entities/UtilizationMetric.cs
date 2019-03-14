using System;

namespace AssetGuard.Core.Entities
{
    public class UtilizationMetric : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime RecordedDate { get; set; } = DateTime.UtcNow;
        public int PeriodDays { get; set; } = 30;
        public int DaysInUse { get; set; }
        public int DaysIdle { get; set; }
        public int DaysInMaintenance { get; set; }
        public decimal UtilizationRate => PeriodDays > 0 ? (decimal)DaysInUse / PeriodDays * 100 : 0;
        public int TotalAssignments { get; set; }
        public int TotalTransfers { get; set; }
    }
}
