using System;

namespace AssetGuard.Core.Entities
{
    public class Consumable : BaseEntity
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
        public int ReorderQuantity { get; set; }
        public decimal UnitCost { get; set; }
        public string Unit { get; set; }
        public int? VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class StockMovement : BaseEntity
    {
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public string MovementType { get; set; }  // In, Out, Adjustment
        public int Quantity { get; set; }
        public int PreviousStock { get; set; }
        public int NewStock { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.UtcNow;
        public int? PerformedById { get; set; }
        public string Reason { get; set; }
        public string ReferenceNumber { get; set; }
    }

    public class ReorderAlert : BaseEntity
    {
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public DateTime AlertDate { get; set; } = DateTime.UtcNow;
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
        public bool IsAcknowledged { get; set; } = false;
        public DateTime? AcknowledgedAt { get; set; }
        public int? PurchaseRequestId { get; set; }
    }
}
