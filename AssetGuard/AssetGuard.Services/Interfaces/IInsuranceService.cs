using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IInsuranceService
    {
        Task<Warranty> AddWarrantyAsync(WarrantyDto dto);
        Task<Warranty> GetWarrantyByIdAsync(int id);
        Task<IEnumerable<Warranty>> GetWarrantiesForAssetAsync(int assetId);
        Task<IEnumerable<Warranty>> GetExpiringWarrantiesAsync(int daysAhead);
        
        Task<InsurancePolicy> AddInsurancePolicyAsync(InsurancePolicyDto dto);
        Task<InsurancePolicy> GetInsurancePolicyByIdAsync(int id);
        Task<IEnumerable<InsurancePolicy>> GetPoliciesForAssetAsync(int assetId);
        Task<IEnumerable<InsurancePolicy>> GetExpiringPoliciesAsync(int daysAhead);
        
        Task<decimal> CalculateTotalCoverageAsync(int assetId);
    }
}
