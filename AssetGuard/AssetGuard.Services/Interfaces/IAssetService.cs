using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDto>> GetAllAssetsAsync();
        Task<AssetDto> GetAssetByIdAsync(int id);
        Task<AssetDto> CreateAssetAsync(CreateAssetDto assetDto);
        Task AssignAssetAsync(int assetId, int employeeId);
        Task ReturnAssetAsync(int assetId);
    }
}
