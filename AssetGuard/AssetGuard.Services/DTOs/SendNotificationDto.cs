using AssetGuard.Core.Entities;

namespace AssetGuard.Services.DTOs
{
    public class SendNotificationDto
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public NotificationChannel Channel { get; set; }
    }
}
