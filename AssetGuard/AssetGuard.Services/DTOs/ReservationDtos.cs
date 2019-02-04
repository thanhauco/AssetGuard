using System;

namespace AssetGuard.Services.DTOs
{
    public class CreateReservationDto
    {
        public int AssetId { get; set; }
        public int RequestedById { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Purpose { get; set; }
        public string Notes { get; set; }
    }

    public class ReservationDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int RequestedById { get; set; }
        public string RequestedByName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }
    }
}
