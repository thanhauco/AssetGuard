using System;

namespace AssetGuard.Services.DTOs
{
    public class PurchaseRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RequestedById { get; set; }
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal EstimatedUnitCost { get; set; }
        public int? BudgetCodeId { get; set; }
        public string Justification { get; set; }
    }

    public class QuoteDto
    {
        public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int VendorId { get; set; }
        public string QuoteNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int LeadTimeDays { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Notes { get; set; }
    }

    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public string PoNumber { get; set; }
        public int PurchaseRequestId { get; set; }
        public int VendorId { get; set; }
        public int? SelectedQuoteId { get; set; }
        public int BudgetCodeId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
    }
}
