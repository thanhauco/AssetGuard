using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface ILicenseService
    {
        Task<IEnumerable<LicenseDto>> GetAllLicensesAsync();
        Task AllocateLicenseAsync(int licenseId, int? assetId, int? userId);
    }
}
