using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IReportingService
    {
        Task<DashboardMetricsDto> GetDashboardMetricsAsync();
        Task<byte[]> GenerateReportAsync(ReportRequestDto request);
        Task<IEnumerable<dynamic>> GetReportDefinitionsAsync();
    }
}
