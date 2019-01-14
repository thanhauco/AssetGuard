using System;

namespace AssetGuard.Core.Entities
{
    public enum QuoteStatus
    {
        Requested,
        Received,
        Selected,
        Rejected,
        Expired
    }

    public class Quote : BaseEntity
    {
        public int PurchaseRequestId { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public string QuoteNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime ValidUntil { get; set; }
        public QuoteStatus Status { get; set; } = QuoteStatus.Requested;
        public string Notes { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.UtcNow;
    }
}
