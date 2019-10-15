using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class PredictiveMaintenanceService : IPredictiveMaintenanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PredictiveMaintenanceService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<PredictiveModel> TrainModelAsync(string name, string datasetUrl)
        {
            var model = new PredictiveModel { Name = name, TrainingDatasetUrl = datasetUrl, TrainedAt = DateTime.UtcNow };
            await _unitOfWork.Repository<PredictiveModel>().AddAsync(model);
            await _unitOfWork.CompleteAsync();
            return model;
        }

        public async Task<MaintenancePrediction> GeneratePredictionAsync(int assetId, int modelId)
        {
            var pred = new MaintenancePrediction { AssetId = assetId, ModelId = modelId, PredictedFailureDate = DateTime.UtcNow.AddDays(30) };
            await _unitOfWork.Repository<MaintenancePrediction>().AddAsync(pred);
            await _unitOfWork.CompleteAsync();
            return pred;
        }

        public async Task<IEnumerable<MaintenancePrediction>> GetAtRiskAssetsAsync(double minConfidence)
        {
            var all = await _unitOfWork.Repository<MaintenancePrediction>().GetAllAsync();
            return all.Where(p => p.ConfidenceScore > minConfidence);
        }

        public async Task<FailureMode> RegisterFailureModeAsync(FailureMode mode)
        {
            await _unitOfWork.Repository<FailureMode>().AddAsync(mode);
            await _unitOfWork.CompleteAsync();
            return mode;
        }

        public async Task<IEnumerable<FailureMode>> GetFailureModesForCategoryAsync(int categoryId)
        {
            var all = await _unitOfWork.Repository<FailureMode>().GetAllAsync();
            return all.Where(f => f.AssetCategoryId == categoryId);
        }
    }
}
