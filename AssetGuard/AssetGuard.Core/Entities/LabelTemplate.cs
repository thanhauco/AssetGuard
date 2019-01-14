using System;

namespace AssetGuard.Core.Entities
{
    public enum LabelSize
    {
        Small,   // 1" x 0.5"
        Medium,  // 2" x 1"
        Large    // 3" x 2"
    }

    public class LabelTemplate : BaseEntity
    {
        public string Name { get; set; }
        public LabelSize Size { get; set; } = LabelSize.Medium;
        public bool IncludeQrCode { get; set; } = true;
        public bool IncludeBarcode { get; set; } = true;
        public bool IncludeAssetName { get; set; } = true;
        public bool IncludeSerialNumber { get; set; } = true;
        public bool IncludeCompanyLogo { get; set; } = false;
        public string LogoUrl { get; set; }
        public string CustomCss { get; set; }
        public bool IsDefault { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
