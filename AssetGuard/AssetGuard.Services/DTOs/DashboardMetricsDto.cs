namespace AssetGuard.Services.DTOs
{
    public class DashboardMetricsDto
    {
        public int TotalAssets { get; set; }
        public decimal TotalValue { get; set; }
        public int PendingIssues { get; set; }
        public int ActiveContracts { get; set; }
    }
}
