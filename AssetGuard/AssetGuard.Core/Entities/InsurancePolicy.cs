using System;

namespace AssetGuard.Core.Entities
{
    public class InsurancePolicy : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string PolicyNumber { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal Premium { get; set; }
        public decimal Deductible { get; set; }
        public decimal CoverageLimit { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CoverageType { get; set; }
        public bool IsActive => DateTime.UtcNow >= EffectiveDate && DateTime.UtcNow <= ExpirationDate;
        public string AgentName { get; set; }
        public string AgentPhone { get; set; }
    }
}
