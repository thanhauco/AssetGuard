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
    public class LicenseService : ILicenseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LicenseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LicenseDto>> GetAllLicensesAsync()
        {
            var licenses = await _unitOfWork.Repository<SoftwareLicense>().GetAllAsync();
            // Need to load allocations to count them
            return licenses.Select(l => new LicenseDto
            {
                Id = l.Id,
                SoftwareName = l.SoftwareName,
                TotalSeats = l.Seats,
                AllocatedSeats = 0, // Placeholder
                ExpirationDate = l.ExpirationDate
            });
        }

        public async Task AllocateLicenseAsync(int licenseId, int? assetId, int? userId)
        {
            var allocation = new LicenseAllocation
            {
                SoftwareLicenseId = licenseId,
                AssetId = assetId,
                UserId = userId,
                AllocatedDate = DateTime.UtcNow
            };
            
            await _unitOfWork.Repository<LicenseAllocation>().AddAsync(allocation);
            await _unitOfWork.CompleteAsync();
        }
    }
}
