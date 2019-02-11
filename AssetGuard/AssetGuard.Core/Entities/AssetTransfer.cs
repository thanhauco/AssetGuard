using System;

namespace AssetGuard.Core.Entities
{
    public enum TransferType
    {
        LocationChange,
        EmployeeReassignment,
        DepartmentTransfer,
        ReturnToPool,
        ExternalLoan
    }

    public class AssetTransfer : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public TransferType Type { get; set; }
        
        public int? FromEmployeeId { get; set; }
        public Employee FromEmployee { get; set; }
        public int? ToEmployeeId { get; set; }
        public Employee ToEmployee { get; set; }
        
        public int? FromRoomId { get; set; }
        public Room FromRoom { get; set; }
        public int? ToRoomId { get; set; }
        public Room ToRoom { get; set; }
        
        public DateTime TransferDate { get; set; } = DateTime.UtcNow;
        public int InitiatedById { get; set; }
        public Employee InitiatedBy { get; set; }
        public string Reason { get; set; }
        public string Notes { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
