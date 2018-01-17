using System;

namespace AssetGuard.Core.Entities
{
    public class AuditLog : BaseEntity
    {
        public string Action { get; set; }
        public string ControllerName { get; set; }
        public string Arguments { get; set; } // JSON serialized
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }
        public string IpAddress { get; set; }
    }
}
