using System;

namespace AssetGuard.Core.Entities
{
    public class AssetForecast : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ForecastDate { get; set; } = DateTime.UtcNow;
        public DateTime PredictedMaintenanceDate { get; set; }
        public DateTime PredictedReplacementDate { get; set; }
        public decimal ProjectedMaintenanceCost { get; set; }
        public decimal ProjectedReplacementCost { get; set; }
        public decimal CurrentBookValue { get; set; }
        public int RemainingUsefulLifeMonths { get; set; }
        public string RiskLevel { get; set; }  // Low, Medium, High, Critical
        public string Notes { get; set; }
    }
}
