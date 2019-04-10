using System;

namespace AssetGuard.Core.Entities
{
    public class ScheduledReport : BaseEntity
    {
        public string Name { get; set; }
        public int ReportDefinitionId { get; set; }
        public ReportDefinition ReportDefinition { get; set; }
        public string Frequency { get; set; }  // Daily, Weekly, Monthly, Quarterly
        public int? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
        public string TimeOfDay { get; set; }
        public string Recipients { get; set; }
        public string Format { get; set; }  // PDF, Excel, CSV
        public bool IsActive { get; set; } = true;
        public DateTime? LastRunAt { get; set; }
        public DateTime? NextRunAt { get; set; }
        public int CreatedById { get; set; }
    }

    public class ReportDelivery : BaseEntity
    {
        public int ScheduledReportId { get; set; }
        public ScheduledReport ScheduledReport { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeliveredAt { get; set; }
        public string Status { get; set; }
        public string FileUrl { get; set; }
        public int RecordCount { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CostCenter : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public CostCenter Parent { get; set; }
        public int? ManagerId { get; set; }
        public decimal AnnualBudget { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CostAllocation : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }
        public decimal AllocationPercent { get; set; } = 100;
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }

    public class CarbonMetric : BaseEntity
    {
        public int? AssetId { get; set; }
        public int? CategoryId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal EnergyConsumptionKwh { get; set; }
        public decimal CarbonEmissionsKg { get; set; }
        public string DataSource { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
    }
}
