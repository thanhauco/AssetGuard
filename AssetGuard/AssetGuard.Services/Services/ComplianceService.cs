using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class ComplianceService : IComplianceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComplianceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ComplianceRequirement> CreateRequirementAsync(ComplianceRequirement requirement)
        {
            await _unitOfWork.Repository<ComplianceRequirement>().AddAsync(requirement);
            await _unitOfWork.CompleteAsync();
            return requirement;
        }

        public async Task<IEnumerable<ComplianceRequirement>> GetActiveRequirementsAsync()
        {
            var all = await _unitOfWork.Repository<ComplianceRequirement>().GetAllAsync();
            return all.Where(r => r.IsActive);
        }

        public async Task<IEnumerable<ComplianceRequirement>> GetRequirementsForCategoryAsync(int categoryId)
        {
            var all = await GetActiveRequirementsAsync();
            return all.Where(r => r.CategoryId == categoryId || r.CategoryId == null);
        }

        public async Task<ComplianceCheck> PerformCheckAsync(int requirementId, int assetId, ComplianceStatus status, int performedById, string notes)
        {
            var requirement = await _unitOfWork.Repository<ComplianceRequirement>().GetByIdAsync(requirementId);
            
            var check = new ComplianceCheck
            {
                ComplianceRequirementId = requirementId,
                AssetId = assetId,
                Status = status,
                PerformedById = performedById,
                Notes = notes,
                NextCheckDue = DateTime.UtcNow.AddDays(requirement.FrequencyDays)
            };

            await _unitOfWork.Repository<ComplianceCheck>().AddAsync(check);
            await _unitOfWork.CompleteAsync();
            return check;
        }

        public async Task<IEnumerable<ComplianceCheck>> GetChecksForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<ComplianceCheck>().GetAllAsync();
            return all.Where(c => c.AssetId == assetId).OrderByDescending(c => c.CheckDate);
        }

        public async Task<IEnumerable<ComplianceCheck>> GetPendingChecksAsync()
        {
            var all = await _unitOfWork.Repository<ComplianceCheck>().GetAllAsync();
            return all.Where(c => c.NextCheckDue <= DateTime.UtcNow);
        }

        public async Task<IEnumerable<Asset>> GetNonCompliantAssetsAsync()
        {
            var checks = await _unitOfWork.Repository<ComplianceCheck>().GetAllAsync();
            var nonCompliantIds = checks.Where(c => c.Status == ComplianceStatus.NonCompliant)
                                        .Select(c => c.AssetId)
                                        .Distinct();
            var assets = await _unitOfWork.Repository<Asset>().GetAllAsync();
            return assets.Where(a => nonCompliantIds.Contains(a.Id));
        }
    }
}
