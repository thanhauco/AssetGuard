namespace AssetGuard.Services.DTOs
{
    public class GenerateTagDto
    {
        public int AssetId { get; set; }
        public int? TemplateId { get; set; }
    }

    public class TagOutputDto
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string SerialNumber { get; set; }
        public string BarcodeData { get; set; }
        public string QrCodeData { get; set; }
        public string HtmlContent { get; set; }
    }

    public class LabelTemplateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public bool IncludeQrCode { get; set; }
        public bool IncludeBarcode { get; set; }
        public bool IncludeAssetName { get; set; }
        public bool IncludeSerialNumber { get; set; }
        public bool IsDefault { get; set; }
    }
}
