using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface ITransferService
    {
        Task<AssetTransfer> InitiateTransferAsync(CreateTransferDto dto);
        Task<AssetTransfer> GetTransferByIdAsync(int id);
        Task<IEnumerable<AssetTransfer>> GetTransferHistoryForAssetAsync(int assetId);
        Task<IEnumerable<AssetTransfer>> GetPendingTransfersAsync();
        Task CompleteTransferAsync(int transferId);
        Task CancelTransferAsync(int transferId, string reason);
        Task<IEnumerable<TransferHistoryDto>> GetAssetMovementReportAsync(int assetId);
    }
}
