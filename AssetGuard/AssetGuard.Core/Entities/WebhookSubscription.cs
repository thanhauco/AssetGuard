using System;

namespace AssetGuard.Core.Entities
{
    public class WebhookSubscription : BaseEntity
    {
        public string Name { get; set; }
        public string TargetUrl { get; set; }
        public string Secret { get; set; }
        public string EventTypes { get; set; }  // Comma-separated: AssetCreated,AssetTransferred,AssetRetired
        public bool IsActive { get; set; } = true;
        public int MaxRetries { get; set; } = 3;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastTriggeredAt { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
    }
}
