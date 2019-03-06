using System;

namespace AssetGuard.Core.Entities
{
    public class OfflineSyncQueue : BaseEntity
    {
        public string DeviceId { get; set; }
        public string OperationType { get; set; }  // Checkout, Return, Scan
        public string PayloadJson { get; set; }
        public DateTime QueuedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public bool IsProcessed { get; set; } = false;
        public string ErrorMessage { get; set; }
        public int RetryCount { get; set; } = 0;
    }
}
