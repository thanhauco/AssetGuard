namespace AssetGuard.Core.Entities
{
    public class AssetComponent : BaseEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int ParentAssetId { get; set; }
        public virtual Asset ParentAsset { get; set; }
        public decimal Cost { get; set; }
    }
}
