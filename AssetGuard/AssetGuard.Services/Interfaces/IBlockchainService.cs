using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IBlockchainService
    {
        Task<BlockTransaction> RecordTransactionAsync(int assetId, string action, object data);
        Task<IEnumerable<BlockTransaction>> GetHistoryAsync(int assetId);
        Task<bool> VerifyTransactionAsync(string hash);
        Task<TokenAsset> TokenizeAssetAsync(int assetId, string ownerAddress, decimal value);
        Task<TokenAsset> TransferTokenAsync(string tokenId, string newOwnerAddress);
    }
}
