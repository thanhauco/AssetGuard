using System;

namespace AssetGuard.Core.Entities
{
    public class Currency : BaseEntity
    {
        public string Code { get; set; } // USD, EUR, GBP
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRateToBase { get; set; } // Base currency assumed to be configured globally
        public DateTime RateUpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }

    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? ParentRegionId { get; set; }
        public Region ParentRegion { get; set; }
        public int DefaultCurrencyId { get; set; }
        public Currency DefaultCurrency { get; set; }
        public string TimeZone { get; set; }
        public string DateFormat { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class TaxJurisdiction : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public string TaxAuthorityName { get; set; }
        public string TaxIdFormat { get; set; }
    }

    public class TaxRule : BaseEntity
    {
        public int JurisdictionId { get; set; }
        public TaxJurisdiction Jurisdiction { get; set; }
        public int? AssetCategoryId { get; set; }
        public string TaxType { get; set; } // Sales, Property, VAT
        public decimal RatePercentage { get; set; }
        public bool IsRecoverable { get; set; } = false;
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
