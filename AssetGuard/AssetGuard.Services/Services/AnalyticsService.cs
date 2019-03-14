using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssetForecast> GenerateForecastAsync(int assetId)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(assetId);
            var maintenanceRecords = await _unitOfWork.Repository<MaintenanceRecord>().GetAllAsync();
            var assetMaintenance = maintenanceRecords.Where(m => m.AssetId == assetId).ToList();

            var avgMaintenanceCost = assetMaintenance.Any() ? assetMaintenance.Average(m => m.Cost) : 0;
            var lastMaintenance = assetMaintenance.OrderByDescending(m => m.DatePerformed).FirstOrDefault();

            var forecast = new AssetForecast
            {
                AssetId = assetId,
                PredictedMaintenanceDate = lastMaintenance?.DatePerformed.AddMonths(6) ?? DateTime.UtcNow.AddMonths(3),
                PredictedReplacementDate = asset.PurchaseDate.AddYears(5),
                ProjectedMaintenanceCost = avgMaintenanceCost * 2,
                ProjectedReplacementCost = asset.PurchasePrice,
                CurrentBookValue = CalculateBookValue(asset),
                RemainingUsefulLifeMonths = CalculateRemainingLife(asset),
                RiskLevel = DetermineRiskLevel(asset)
            };

            await _unitOfWork.Repository<AssetForecast>().AddAsync(forecast);
            await _unitOfWork.CompleteAsync();
            return forecast;
        }

        public async Task<IEnumerable<AssetForecast>> GetForecastsForCategoryAsync(int categoryId)
        {
            var all = await _unitOfWork.Repository<AssetForecast>().GetAllAsync();
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            var categoryAssetIds = assets.Where(a => a.CategoryId == categoryId).Select(a => a.Id);
            return all.Where(f => categoryAssetIds.Contains(f.AssetId));
        }

        public async Task<UtilizationMetric> CalculateUtilizationAsync(int assetId, int periodDays)
        {
            var assignments = await _unitOfWork.Repository<Assignment>().GetAllAsync();
            var assetAssignments = assignments.Where(a => a.AssetId == assetId).ToList();

            var metric = new UtilizationMetric
            {
                AssetId = assetId,
                PeriodDays = periodDays,
                DaysInUse = assetAssignments.Count * 5, // Simplified
                DaysIdle = periodDays - (assetAssignments.Count * 5),
                TotalAssignments = assetAssignments.Count
            };

            await _unitOfWork.Repository<UtilizationMetric>().AddAsync(metric);
            await _unitOfWork.CompleteAsync();
            return metric;
        }

        public async Task<IEnumerable<UtilizationMetric>> GetLowUtilizationAssetsAsync(decimal thresholdPercent)
        {
            var all = await _unitOfWork.Repository<UtilizationMetric>().GetAllAsync();
            return all.Where(m => m.UtilizationRate < thresholdPercent);
        }

        public async Task<CostProjection> GenerateCostProjectionAsync(int fiscalYear, int? categoryId)
        {
            var projection = new CostProjection
            {
                CategoryId = categoryId,
                FiscalYear = fiscalYear,
                FiscalQuarter = 1,
                ProjectedMaintenanceCost = 10000,
                ProjectedReplacementCost = 50000,
                ProjectedInsuranceCost = 5000
            };

            await _unitOfWork.Repository<CostProjection>().AddAsync(projection);
            await _unitOfWork.CompleteAsync();
            return projection;
        }

        public async Task<IEnumerable<CostProjection>> GetProjectionsByYearAsync(int fiscalYear)
        {
            var all = await _unitOfWork.Repository<CostProjection>().GetAllAsync();
            return all.Where(p => p.FiscalYear == fiscalYear);
        }

        public async Task<IEnumerable<Asset>> GetAssetsNeedingReplacementAsync(int monthsAhead)
        {
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            var cutoff = DateTime.UtcNow.AddMonths(monthsAhead);
            return assets.Where(a => a.PurchaseDate.AddYears(5) <= cutoff);
        }

        public async Task<IEnumerable<Asset>> GetAssetsNeedingMaintenanceAsync(int daysAhead)
        {
            var records = await _unitOfWork.Repository<MaintenanceRecord>().GetAllAsync();
            var cutoff = DateTime.UtcNow.AddDays(-180 + daysAhead);
            var recentlyMaintained = records.Where(m => m.DatePerformed >= cutoff).Select(m => m.AssetId);
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            return assets.Where(a => !recentlyMaintained.Contains(a.Id));
        }

        private decimal CalculateBookValue(Asset asset)
        {
            var age = (DateTime.UtcNow - asset.PurchaseDate).Days / 365.0;
            var depreciation = asset.PurchasePrice * (decimal)(age / 5.0);
            return Math.Max(0, asset.PurchasePrice - depreciation);
        }

        private int CalculateRemainingLife(Asset asset)
        {
            var endOfLife = asset.PurchaseDate.AddYears(5);
            var remaining = (endOfLife - DateTime.UtcNow).Days / 30;
            return Math.Max(0, remaining);
        }

        private string DetermineRiskLevel(Asset asset)
        {
            var remainingMonths = CalculateRemainingLife(asset);
            if (remainingMonths <= 6) return "Critical";
            if (remainingMonths <= 12) return "High";
            if (remainingMonths <= 24) return "Medium";
            return "Low";
        }
    }
}
