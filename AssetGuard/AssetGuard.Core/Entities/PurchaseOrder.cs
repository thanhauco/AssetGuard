using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public enum PurchaseOrderStatus
    {
        Draft,
        Sent,
        Acknowledged,
        PartiallyReceived,
        Received,
        Cancelled
    }

    public class PurchaseOrder : BaseEntity
    {
        public string PoNumber { get; set; }
        public int PurchaseRequestId { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public int? SelectedQuoteId { get; set; }
        public Quote SelectedQuote { get; set; }
        public int BudgetCodeId { get; set; }
        public BudgetCode BudgetCode { get; set; }
        public decimal TotalAmount { get; set; }
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
        public int CreatedById { get; set; }
        
        public ICollection<Asset> ReceivedAssets { get; set; } = new List<Asset>();
    }
}
