using System;

namespace AssetGuard.Core.Entities
{
    public class ReportSchedule : BaseEntity
    {
        public int ReportDefinitionId { get; set; }
        public virtual ReportDefinition ReportDefinition { get; set; }

        public string CronExpression { get; set; }
        public DateTime? LastRun { get; set; }
        public bool IsEnabled { get; set; }
        public string Recipients { get; set; } // Comma separated emails
    }
}
