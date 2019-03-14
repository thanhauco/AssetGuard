using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IBulkOperationService
    {
        Task<BulkOperation> StartBulkUpdateAsync(string inputFileUrl, int initiatedById);
        Task<BulkOperation> StartBulkRetireAsync(IEnumerable<int> assetIds, int initiatedById);
        Task<BulkOperation> StartBulkTransferAsync(IEnumerable<int> assetIds, int toRoomId, int initiatedById);
        Task<BulkOperation> GetOperationStatusAsync(int operationId);
        Task<IEnumerable<BulkOperation>> GetRecentOperationsAsync(int count);
        Task<string> ExportAssetsAsync(IEnumerable<int> assetIds, string format);
        
        Task<Asset> CloneAssetAsync(int sourceAssetId, string newSerialNumber);
        Task<IEnumerable<Asset>> CloneAssetBatchAsync(int sourceAssetId, int count, string serialPrefix);
    }
}
