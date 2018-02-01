using System;

namespace AssetGuard.Services.DTOs
{
    public class ReportRequestDto
    {
        public int ReportDefinitionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Format { get; set; } // "PDF", "CSV"
    }
}
