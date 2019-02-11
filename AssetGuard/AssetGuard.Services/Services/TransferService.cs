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
    public class TransferService : ITransferService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AssetTransfer> InitiateTransferAsync(CreateTransferDto dto)
        {
            var transfer = new AssetTransfer
            {
                AssetId = dto.AssetId,
                Type = Enum.Parse<TransferType>(dto.TransferType),
                FromEmployeeId = dto.FromEmployeeId,
                ToEmployeeId = dto.ToEmployeeId,
                FromRoomId = dto.FromRoomId,
                ToRoomId = dto.ToRoomId,
                InitiatedById = dto.InitiatedById,
                Reason = dto.Reason,
                Notes = dto.Notes,
                IsCompleted = false
            };

            await _unitOfWork.Repository<AssetTransfer>().AddAsync(transfer);
            await _unitOfWork.CompleteAsync();
            return transfer;
        }

        public async Task<AssetTransfer> GetTransferByIdAsync(int id)
        {
            return await _unitOfWork.Repository<AssetTransfer>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<AssetTransfer>> GetTransferHistoryForAssetAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<AssetTransfer>().GetAllAsync();
            return all.Where(t => t.AssetId == assetId).OrderByDescending(t => t.TransferDate);
        }

        public async Task<IEnumerable<AssetTransfer>> GetPendingTransfersAsync()
        {
            var all = await _unitOfWork.Repository<AssetTransfer>().GetAllAsync();
            return all.Where(t => !t.IsCompleted);
        }

        public async Task CompleteTransferAsync(int transferId)
        {
            var transfer = await GetTransferByIdAsync(transferId);
            transfer.IsCompleted = true;
            transfer.CompletedAt = DateTime.UtcNow;

            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(transfer.AssetId);
            if (transfer.ToRoomId.HasValue)
                asset.RoomId = transfer.ToRoomId;

            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelTransferAsync(int transferId, string reason)
        {
            var transfer = await GetTransferByIdAsync(transferId);
            transfer.Notes = $"CANCELLED: {reason}";
            transfer.IsCompleted = true;
            transfer.CompletedAt = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<TransferHistoryDto>> GetAssetMovementReportAsync(int assetId)
        {
            var transfers = await GetTransferHistoryForAssetAsync(assetId);
            return transfers.Select(t => new TransferHistoryDto
            {
                Id = t.Id,
                AssetId = t.AssetId,
                TransferType = t.Type.ToString(),
                TransferDate = t.TransferDate,
                Reason = t.Reason
            });
        }
    }
}
