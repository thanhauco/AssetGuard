using System;

namespace AssetGuard.Core.Entities
{
    public enum ReservationStatus
    {
        Pending,
        Approved,
        Active,
        Completed,
        Cancelled
    }

    public class AssetReservation : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int RequestedById { get; set; }
        public Employee RequestedBy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Purpose { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
        public int? ApprovedById { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
    }
}
