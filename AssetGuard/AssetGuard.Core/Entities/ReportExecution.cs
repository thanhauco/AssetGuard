using System;

namespace AssetGuard.Core.Entities
{
    public class ReportExecution : BaseEntity
    {
        public int ReportDefinitionId { get; set; }
        public DateTime ExecutedAt { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string ResultLocation { get; set; } // Path to generated file
    }
}
