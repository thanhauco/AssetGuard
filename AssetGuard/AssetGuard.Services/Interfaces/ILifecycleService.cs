using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface ILifecycleService
    {
        Task<AssetLifecycle> TransitionStageAsync(int assetId, LifecycleStage newStage, int changedById, string reason);
        Task<IEnumerable<AssetLifecycle>> GetLifecycleHistoryAsync(int assetId);
        Task<LifecycleStage> GetCurrentStageAsync(int assetId);
        
        Task<LifecyclePolicy> CreatePolicyAsync(LifecyclePolicy policy);
        Task<LifecyclePolicy> GetPolicyForCategoryAsync(int categoryId);
        Task<IEnumerable<Asset>> GetAssetsAtEndOfLifeAsync();
    }
}
