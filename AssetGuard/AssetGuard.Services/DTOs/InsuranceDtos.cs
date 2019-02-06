using System;

namespace AssetGuard.Services.DTOs
{
    public class WarrantyDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? CoverageAmount { get; set; }
        public string CoverageDetails { get; set; }
    }

    public class InsurancePolicyDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal Premium { get; set; }
        public decimal CoverageLimit { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
