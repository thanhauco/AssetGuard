using System;

namespace AssetGuard.Core.Entities
{
    public class AssetNote : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string Content { get; set; }
        public int CreatedById { get; set; }
        public Employee CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsPinned { get; set; } = false;
        public bool IsInternal { get; set; } = false;
    }

    public class AssetTag : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public int UsageCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class AssetTagAssignment : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int TagId { get; set; }
        public AssetTag Tag { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public int AssignedById { get; set; }
    }

    public enum RelationshipType
    {
        ParentChild,
        Accessory,
        Replacement,
        Dependency,
        Bundle
    }

    public class AssetRelationship : BaseEntity
    {
        public int PrimaryAssetId { get; set; }
        public Asset PrimaryAsset { get; set; }
        public int RelatedAssetId { get; set; }
        public Asset RelatedAsset { get; set; }
        public RelationshipType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }

    public class MaintenanceSchedule : BaseEntity
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? AssetId { get; set; }
        public Asset Asset { get; set; }
        public string MaintenanceType { get; set; }
        public int FrequencyDays { get; set; }
        public string Instructions { get; set; }
        public decimal EstimatedCost { get; set; }
        public int EstimatedDurationMinutes { get; set; }
        public int? AssignedVendorId { get; set; }
        public bool RequiresDowntime { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime? LastPerformedAt { get; set; }
        public DateTime? NextDueAt { get; set; }
    }
}
