using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class AssetKit : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string KitNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public int? CategoryId { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<KitComponent> Components { get; set; }
    }

    public class KitComponent : BaseEntity
    {
        public int KitId { get; set; }
        public AssetKit Kit { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int Quantity { get; set; } = 1;
        public bool IsRequired { get; set; } = true;
        public string Notes { get; set; }
    }

    public class SparePart : BaseEntity
    {
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public int CompatibleCategoryId { get; set; }
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
        public decimal UnitCost { get; set; }
        public int? VendorId { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class PartUsageLog : BaseEntity
    {
        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }
        public int? MaintenanceRecordId { get; set; }
        public int AssetId { get; set; }
        public int Quantity { get; set; }
        public DateTime UsedDate { get; set; } = DateTime.UtcNow;
        public int UsedById { get; set; }
        public string Notes { get; set; }
    }
}
