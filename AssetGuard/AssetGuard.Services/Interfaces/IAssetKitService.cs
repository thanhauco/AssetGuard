using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IAssetKitService
    {
        Task<AssetKit> CreateKitAsync(AssetKit kit);
        Task<AssetKit> GetKitByIdAsync(int id);
        Task<IEnumerable<AssetKit>> GetAllKitsAsync();
        
        Task AddComponentAsync(int kitId, int assetId, int quantity, bool isRequired);
        Task RemoveComponentAsync(int kitId, int assetId);
        Task<IEnumerable<KitComponent>> GetKitComponentsAsync(int kitId);
        
        Task<decimal> CalculateKitValueAsync(int kitId);
    }
}
