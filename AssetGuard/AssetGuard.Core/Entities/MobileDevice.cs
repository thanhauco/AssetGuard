using System;

namespace AssetGuard.Core.Entities
{
    public class MobileDevice : BaseEntity
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Platform { get; set; }  // iOS, Android
        public string AppVersion { get; set; }
        public int? AssignedToId { get; set; }
        public Employee AssignedTo { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastSyncAt { get; set; }
        public bool IsActive { get; set; } = true;
        public string PushToken { get; set; }
    }
}
