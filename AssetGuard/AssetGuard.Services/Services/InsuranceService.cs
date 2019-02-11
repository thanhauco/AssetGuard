using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsuranceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Warranty> AddWarrantyAsync(WarrantyDto dto)
        {
            var warranty = new Warranty
            {
                AssetId = dto.AssetId,
                Type = Enum.Parse<WarrantyType>(dto.Type),
                Provider = dto.Provider,
                PolicyNumber = dto.PolicyNumber,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CoverageAmount = dto.CoverageAmount,
                CoverageDetails = dto.CoverageDetails
            };

            await _unitOfWork.Repository<Warranty>().AddAsync(warranty);
            await _unitOfWork.CompleteAsync();
            return warranty;
        }

        public async Task<Warranty> GetWarrantyByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Warranty>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<Warranty>> GetWarrantiesForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<Warranty>().GetAllAsync();
            return all.Where(w => w.AssetId == assetId);
        }

        public async Task<IEnumerable<Warranty>> GetExpiringWarrantiesAsync(int daysAhead)
        {
            var all = await _unitOfWork.Repository<Warranty>().GetAllAsync();
            var cutoff = DateTime.UtcNow.AddDays(daysAhead);
            return all.Where(w => w.EndDate <= cutoff && w.EndDate >= DateTime.UtcNow);
        }

        public async Task<InsurancePolicy> AddInsurancePolicyAsync(InsurancePolicyDto dto)
        {
            var policy = new InsurancePolicy
            {
                AssetId = dto.AssetId,
                PolicyNumber = dto.PolicyNumber,
                InsuranceCompany = dto.InsuranceCompany,
                Premium = dto.Premium,
                CoverageLimit = dto.CoverageLimit,
                EffectiveDate = dto.EffectiveDate,
                ExpirationDate = dto.ExpirationDate
            };

            await _unitOfWork.Repository<InsurancePolicy>().AddAsync(policy);
            await _unitOfWork.CompleteAsync();
            return policy;
        }

        public async Task<InsurancePolicy> GetInsurancePolicyByIdAsync(int id)
        {
            return await _unitOfWork.Repository<InsurancePolicy>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<InsurancePolicy>> GetPoliciesForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<InsurancePolicy>().GetAllAsync();
            return all.Where(p => p.AssetId == assetId);
        }

        public async Task<IEnumerable<InsurancePolicy>> GetExpiringPoliciesAsync(int daysAhead)
        {
            var all = await _unitOfWork.Repository<InsurancePolicy>().GetAllAsync();
            var cutoff = DateTime.UtcNow.AddDays(daysAhead);
            return all.Where(p => p.ExpirationDate <= cutoff && p.ExpirationDate >= DateTime.UtcNow);
        }

        public async Task<decimal> CalculateTotalCoverageAsync(int assetId)
        {
            var warranties = await GetWarrantiesForAssetAsync(assetId);
            var policies = await GetPoliciesForAssetAsync(assetId);

            var warrantyCoverage = warranties.Where(w => w.IsActive).Sum(w => w.CoverageAmount ?? 0);
            var insuranceCoverage = policies.Where(p => p.IsActive).Sum(p => p.CoverageLimit);

            return warrantyCoverage + insuranceCoverage;
        }
    }
}
