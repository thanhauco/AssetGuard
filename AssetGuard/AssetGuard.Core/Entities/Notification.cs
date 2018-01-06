using System;

namespace AssetGuard.Core.Entities
{
    public class Notification : BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; } // Recipient
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public NotificationChannel Channel { get; set; }
    }

    public enum NotificationChannel
    {
        InApp,
        Email,
        SMS
    }
}
