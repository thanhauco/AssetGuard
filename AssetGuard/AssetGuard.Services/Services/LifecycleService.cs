using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class LifecycleService : ILifecycleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LifecycleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssetLifecycle> TransitionStageAsync(int assetId, LifecycleStage newStage, int changedById, string reason)
        {
            var history = await GetLifecycleHistoryAsync(assetId);
            var current = history.FirstOrDefault(h => h.StageEndDate == null);
            
            if (current != null)
            {
                current.StageEndDate = DateTime.UtcNow;
            }

            var lifecycle = new AssetLifecycle
            {
                AssetId = assetId,
                Stage = newStage,
                ChangedById = changedById,
                Reason = reason
            };

            await _unitOfWork.Repository<AssetLifecycle>().AddAsync(lifecycle);
            await _unitOfWork.CompleteAsync();
            return lifecycle;
        }

        public async Task<IEnumerable<AssetLifecycle>> GetLifecycleHistoryAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<AssetLifecycle>().GetAllAsync();
            return all.Where(l => l.AssetId == assetId).OrderByDescending(l => l.StageStartDate);
        }

        public async Task<LifecycleStage> GetCurrentStageAsync(int assetId)
        {
            var history = await GetLifecycleHistoryAsync(assetId);
            var current = history.FirstOrDefault(h => h.StageEndDate == null);
            return current?.Stage ?? LifecycleStage.Procurement;
        }

        public async Task<LifecyclePolicy> CreatePolicyAsync(LifecyclePolicy policy)
        {
            await _unitOfWork.Repository<LifecyclePolicy>().AddAsync(policy);
            await _unitOfWork.CompleteAsync();
            return policy;
        }

        public async Task<LifecyclePolicy> GetPolicyForCategoryAsync(int categoryId)
        {
            var all = await _unitOfWork.Repository<LifecyclePolicy>().GetAllAsync();
            return all.FirstOrDefault(p => p.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Asset>> GetAssetsAtEndOfLifeAsync()
        {
            var policies = await _unitOfWork.Repository<LifecyclePolicy>().GetAllAsync();
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            
            return assets.Where(a => {
                var policy = policies.FirstOrDefault(p => p.CategoryId == a.CategoryId);
                if (policy == null) return false;
                var endOfLife = a.PurchaseDate.AddMonths(policy.ExpectedLifespanMonths);
                return endOfLife <= DateTime.UtcNow.AddMonths(policy.WarningThresholdMonths);
            });
        }
    }
}
