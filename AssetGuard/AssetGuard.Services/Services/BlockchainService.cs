using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlockchainService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<BlockTransaction> RecordTransactionAsync(int assetId, string action, object data)
        {
            var tx = new BlockTransaction { AssetId = assetId, ActionType = action, Timestamp = DateTime.UtcNow, TransactionHash = Guid.NewGuid().ToString() };
            await _unitOfWork.Repository<BlockTransaction>().AddAsync(tx);
            await _unitOfWork.CompleteAsync();
            return tx;
        }

        public async Task<IEnumerable<BlockTransaction>> GetHistoryAsync(int assetId)
        {
            var all = await _unitOfWork.Repository<BlockTransaction>().GetAllAsync();
            return all.Where(t => t.AssetId == assetId);
        }

        public async Task<bool> VerifyTransactionAsync(string hash) => true;

        public async Task<TokenAsset> TokenizeAssetAsync(int assetId, string ownerAddress, decimal value)
        {
            var token = new TokenAsset { AssetId = assetId, OwnerWalletAddress = ownerAddress, TokenValue = value, TokenId = Guid.NewGuid().ToString() };
            await _unitOfWork.Repository<TokenAsset>().AddAsync(token);
            await _unitOfWork.CompleteAsync();
            return token;
        }

        public async Task<TokenAsset> TransferTokenAsync(string tokenId, string newOwnerAddress)
        {
            var all = await _unitOfWork.Repository<TokenAsset>().GetAllAsync();
            var token = all.FirstOrDefault(t => t.TokenId == tokenId);
            if(token != null) { token.OwnerWalletAddress = newOwnerAddress; await _unitOfWork.CompleteAsync(); }
            return token;
        }
    }
}
