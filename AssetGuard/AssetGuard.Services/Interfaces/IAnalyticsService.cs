using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IAnalyticsService
    {
        Task<AssetForecast> GenerateForecastAsync(int assetId);
        Task<IEnumerable<AssetForecast>> GetForecastsForCategoryAsync(int categoryId);
        Task<UtilizationMetric> CalculateUtilizationAsync(int assetId, int periodDays);
        Task<IEnumerable<UtilizationMetric>> GetLowUtilizationAssetsAsync(decimal thresholdPercent);
        Task<CostProjection> GenerateCostProjectionAsync(int fiscalYear, int? categoryId);
        Task<IEnumerable<CostProjection>> GetProjectionsByYearAsync(int fiscalYear);
        Task<IEnumerable<Asset>> GetAssetsNeedingReplacementAsync(int monthsAhead);
        Task<IEnumerable<Asset>> GetAssetsNeedingMaintenanceAsync(int daysAhead);
    }
}
