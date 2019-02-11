using System;

namespace AssetGuard.Core.Entities
{
    public enum WarrantyType
    {
        Manufacturer,
        Extended,
        ThirdParty
    }

    public class Warranty : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public WarrantyType Type { get; set; }
        public string Provider { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? CoverageAmount { get; set; }
        public string CoverageDetails { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool IsActive => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
    }
}
