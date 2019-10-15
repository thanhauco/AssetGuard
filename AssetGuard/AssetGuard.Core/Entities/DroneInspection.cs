using System;

namespace AssetGuard.Core.Entities
{
    public class DroneFlight : BaseEntity
    {
        public string FlightNumber { get; set; }
        public string DroneId { get; set; }
        public int RegionId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string FlightPathUrl { get; set; }
    }

    public class InspectionImage : BaseEntity
    {
        public int DroneFlightId { get; set; }
        public int? AssetId { get; set; }
        public string ImageUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public DateTime CapturedAt { get; set; }
        public bool HasDefect { get; set; } = false;
    }

    public class Defect : BaseEntity
    {
        public int InspectionImageId { get; set; }
        public int AssetId { get; set; }
        public string DefectType { get; set; }
        public double Confidence { get; set; }
        public string BoundingBox { get; set; }
        public string Severity { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
