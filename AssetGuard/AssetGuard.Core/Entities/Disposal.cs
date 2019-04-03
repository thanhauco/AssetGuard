using System;

namespace AssetGuard.Core.Entities
{
    public enum DisposalMethod
    {
        Sale,
        Donation,
        Recycling,
        TradeIn,
        Destruction,
        InternalTransfer,
        ReturnToVendor
    }

    public enum DisposalStatus
    {
        Pending,
        Approved,
        InProgress,
        Completed,
        Cancelled
    }

    public class DisposalRequest : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DisposalMethod Method { get; set; }
        public DisposalStatus Status { get; set; } = DisposalStatus.Pending;
        public int RequestedById { get; set; }
        public Employee RequestedBy { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public int? ApprovedById { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Justification { get; set; }
        public decimal EstimatedSalvageValue { get; set; }
        public decimal ActualSalvageValue { get; set; }
        public bool DataWipeCompleted { get; set; } = false;
        public string DataWipeCertificateUrl { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string RecipientInfo { get; set; }
        public string Notes { get; set; }
    }

    public class DisposalCertificate : BaseEntity
    {
        public int DisposalRequestId { get; set; }
        public DisposalRequest DisposalRequest { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public string IssuedBy { get; set; }
        public string DocumentUrl { get; set; }
        public string EnvironmentalCompliance { get; set; }
    }
}
