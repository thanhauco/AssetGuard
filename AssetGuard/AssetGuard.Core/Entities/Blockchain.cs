using System;

namespace AssetGuard.Core.Entities
{
    public class BlockTransaction : BaseEntity
    {
        public string TransactionHash { get; set; }
        public string BlockNumber { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string ActionType { get; set; }
        public string DataPayload { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string PreviousHash { get; set; }
        public bool IsVerified { get; set; } = true;
    }

    public class SmartContract : BaseEntity
    {
        public string Name { get; set; }
        public string ContractAddress { get; set; }
        public string AbiDefinition { get; set; }
        public string Network { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DeployedAt { get; set; }
    }

    public class TokenAsset : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string TokenId { get; set; }
        public string ContractAddress { get; set; }
        public string OwnerWalletAddress { get; set; }
        public decimal TokenValue { get; set; }
        public DateTime MintedAt { get; set; }
    }
}
