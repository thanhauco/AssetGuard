using System;

namespace AssetGuard.Core.Entities
{
    public class CostProjection : BaseEntity
    {
        public int? AssetId { get; set; }
        public int? CategoryId { get; set; }
        public int? DepartmentId { get; set; }
        public int FiscalYear { get; set; }
        public int FiscalQuarter { get; set; }
        public decimal ProjectedMaintenanceCost { get; set; }
        public decimal ProjectedReplacementCost { get; set; }
        public decimal ProjectedInsuranceCost { get; set; }
        public decimal TotalProjectedCost => ProjectedMaintenanceCost + ProjectedReplacementCost + ProjectedInsuranceCost;
        public decimal ActualCost { get; set; }
        public decimal Variance => TotalProjectedCost - ActualCost;
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}
