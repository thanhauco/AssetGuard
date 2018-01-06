namespace AssetGuard.Core.Entities
{
    public class UserSubscription : BaseEntity
    {
        public int UserId { get; set; }
        public string EventKey { get; set; } // "AssetAssigned", "MaintenanceDue"
        public bool IsEnabled { get; set; }
        public NotificationChannel PreferredChannel { get; set; }
    }
}
