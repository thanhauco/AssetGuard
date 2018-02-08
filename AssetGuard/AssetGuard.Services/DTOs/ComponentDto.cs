namespace AssetGuard.Services.DTOs
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int ParentAssetId { get; set; }
    }
}
