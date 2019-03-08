using System;

namespace AssetGuard.Core.Entities
{
    public enum SyncJobStatus
    {
        Pending,
        Running,
        Completed,
        Failed,
        Cancelled
    }

    public class SyncJob : BaseEntity
    {
        public int IntegrationConfigId { get; set; }
        public IntegrationConfig IntegrationConfig { get; set; }
        public SyncJobStatus Status { get; set; } = SyncJobStatus.Pending;
        public DateTime ScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int RecordsProcessed { get; set; }
        public int RecordsCreated { get; set; }
        public int RecordsUpdated { get; set; }
        public int RecordsFailed { get; set; }
        public string ErrorLog { get; set; }
    }
}
