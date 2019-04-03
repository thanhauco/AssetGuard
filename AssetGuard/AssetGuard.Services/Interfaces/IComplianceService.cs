using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IComplianceService
    {
        Task<ComplianceRequirement> CreateRequirementAsync(ComplianceRequirement requirement);
        Task<IEnumerable<ComplianceRequirement>> GetActiveRequirementsAsync();
        Task<IEnumerable<ComplianceRequirement>> GetRequirementsForCategoryAsync(int categoryId);
        
        Task<ComplianceCheck> PerformCheckAsync(int requirementId, int assetId, ComplianceStatus status, int performedById, string notes);
        Task<IEnumerable<ComplianceCheck>> GetChecksForAssetAsync(int assetId);
        Task<IEnumerable<ComplianceCheck>> GetPendingChecksAsync();
        Task<IEnumerable<Asset>> GetNonCompliantAssetsAsync();
    }
}
