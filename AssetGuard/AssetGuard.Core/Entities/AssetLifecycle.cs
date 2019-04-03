using System;

namespace AssetGuard.Core.Entities
{
    public enum LifecycleStage
    {
        Procurement,
        Deployment,
        InService,
        Maintenance,
        Storage,
        EndOfLife,
        Disposed
    }

    public class AssetLifecycle : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public LifecycleStage Stage { get; set; }
        public DateTime StageStartDate { get; set; } = DateTime.UtcNow;
        public DateTime? StageEndDate { get; set; }
        public int? ChangedById { get; set; }
        public Employee ChangedBy { get; set; }
        public string Notes { get; set; }
        public string Reason { get; set; }
    }

    public class LifecyclePolicy : BaseEntity
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int ExpectedLifespanMonths { get; set; } = 60;
        public int WarningThresholdMonths { get; set; } = 6;
        public decimal MinResidualValue { get; set; }
        public bool AutoNotifyOnEndOfLife { get; set; } = true;
        public string DisposalInstructions { get; set; }
        public bool RequiresDataWipe { get; set; } = false;
    }
}
