using System;

namespace AssetGuard.Services.DTOs
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string CategoryName { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Status { get; set; } // Derived based on assignments
    }
}
