using System;

namespace AssetGuard.Services.DTOs
{
    public class CreateAuditSessionDto
    {
        public string Name { get; set; }
        public int? SiteId { get; set; }
        public int? BuildingId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int ConductedById { get; set; }
        public string Notes { get; set; }
    }

    public class RecordScanDto
    {
        public int AuditSessionId { get; set; }
        public int AssetId { get; set; }
        public int ScannedById { get; set; }
        public int? FoundInRoomId { get; set; }
        public string Condition { get; set; }
        public string Notes { get; set; }
    }

    public class ResolveDiscrepancyDto
    {
        public int DiscrepancyId { get; set; }
        public string Resolution { get; set; }
        public string ResolutionNotes { get; set; }
        public int ResolvedById { get; set; }
    }

    public class AuditSummaryDto
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public int TotalExpected { get; set; }
        public int TotalScanned { get; set; }
        public int TotalMissing { get; set; }
        public int TotalDiscrepancies { get; set; }
        public decimal CompletionPercentage { get; set; }
    }
}
