using System;

namespace AssetGuard.Core.Entities
{
    public class AssetLocation : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
        public double? Accuracy { get; set; }
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
        public string Source { get; set; }  // GPS, WiFi, Manual
        public string DeviceId { get; set; }
        public string Address { get; set; }
    }

    public class GeoFence : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }
        public double RadiusMeters { get; set; }
        public string PolygonCoordinates { get; set; }  // JSON for complex shapes
        public bool AlertOnExit { get; set; } = true;
        public bool AlertOnEntry { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int? SiteId { get; set; }
        public Site Site { get; set; }
    }

    public class GeoFenceViolation : BaseEntity
    {
        public int GeoFenceId { get; set; }
        public GeoFence GeoFence { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string ViolationType { get; set; }  // Entry, Exit
        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsAcknowledged { get; set; } = false;
        public int? AcknowledgedById { get; set; }
    }

    public class AssetPhoto : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string PhotoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Caption { get; set; }
        public string PhotoType { get; set; }  // Condition, Installation, Damage
        public DateTime TakenAt { get; set; } = DateTime.UtcNow;
        public int? TakenById { get; set; }
        public string DeviceId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
