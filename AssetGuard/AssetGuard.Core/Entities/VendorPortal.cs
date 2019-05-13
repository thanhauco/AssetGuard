using System;

namespace AssetGuard.Core.Entities
{
    public class VendorPortalUser : BaseEntity
    {
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }
        public string Permissions { get; set; } // JSON
    }

    public enum RfpStatus
    {
        Draft,
        Open,
        Closed,
        Awarded,
        Cancelled
    }

    public class RequestForProposal : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public RfpStatus Status { get; set; } = RfpStatus.Draft;
        public int CreatedById { get; set; }
        public decimal? BudgetEstimate { get; set; }
        public string RequirementsDocUrl { get; set; }
    }

    public class VendorBid : BaseEntity
    {
        public int RfpId { get; set; }
        public RequestForProposal Rfp { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        public string ProposalDocUrl { get; set; }
        public int DeliveryTimeDays { get; set; }
        public bool IsShortlisted { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public string SelectionNotes { get; set; }
    }

    public class ContractRenewalAlert : BaseEntity
    {
        public int ContractId { get; set; } // Assuming Contract entity exists from Release 1.0/2.0
        public int DaysBeforeExpiration { get; set; }
        public bool NotifyVendor { get; set; } = true;
        public bool NotifyInternal { get; set; } = true;
        public bool IsSent { get; set; } = false;
        public DateTime? SentAt { get; set; }
    }
}
