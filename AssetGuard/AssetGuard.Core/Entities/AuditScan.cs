using System;

namespace AssetGuard.Core.Entities
{
    public class AuditScan : BaseEntity
    {
        public int AuditSessionId { get; set; }
        public AuditSession AuditSession { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ScannedAt { get; set; } = DateTime.UtcNow;
        public int ScannedById { get; set; }
        public Employee ScannedBy { get; set; }
        public int? FoundInRoomId { get; set; }
        public Room FoundInRoom { get; set; }
        public string Condition { get; set; }
        public string Notes { get; set; }
        public bool LocationMismatch { get; set; }
    }
}
