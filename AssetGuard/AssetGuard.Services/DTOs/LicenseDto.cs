using System;

namespace AssetGuard.Services.DTOs
{
    public class LicenseDto
    {
        public int Id { get; set; }
        public string SoftwareName { get; set; }
        public int TotalSeats { get; set; }
        public int AllocatedSeats { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
