namespace AssetGuard.Core.Entities
{
    public class NotificationTemplate : BaseEntity
    {
        public string Key { get; set; } // e.g., "WelcomeEmail", "IssueCreated"
        public string SubjectTemplate { get; set; }
        public string BodyTemplate { get; set; }
        public NotificationChannel DefaultChannel { get; set; }
    }
}
