using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IPredictiveMaintenanceService
    {
        Task<PredictiveModel> TrainModelAsync(string name, string datasetUrl);
        Task<MaintenancePrediction> GeneratePredictionAsync(int assetId, int modelId);
        Task<IEnumerable<MaintenancePrediction>> GetAtRiskAssetsAsync(double minConfidence);
        Task<FailureMode> RegisterFailureModeAsync(FailureMode mode);
        Task<IEnumerable<FailureMode>> GetFailureModesForCategoryAsync(int categoryId);
    }
}
