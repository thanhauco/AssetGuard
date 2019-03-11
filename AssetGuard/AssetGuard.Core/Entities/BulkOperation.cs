using System;

namespace AssetGuard.Core.Entities
{
    public enum BulkOperationType
    {
        Update,
        Retire,
        Transfer,
        Delete,
        Export
    }

    public enum BulkOperationStatus
    {
        Pending,
        Processing,
        Completed,
        PartiallyCompleted,
        Failed
    }

    public class BulkOperation : BaseEntity
    {
        public BulkOperationType OperationType { get; set; }
        public BulkOperationStatus Status { get; set; } = BulkOperationStatus.Pending;
        public int InitiatedById { get; set; }
        public DateTime InitiatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public int TotalRecords { get; set; }
        public int ProcessedRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public string InputFileUrl { get; set; }
        public string OutputFileUrl { get; set; }
        public string ErrorLog { get; set; }
    }
}
