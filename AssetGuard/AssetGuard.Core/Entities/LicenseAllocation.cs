using System;

namespace AssetGuard.Core.Entities
{
    public class LicenseAllocation : BaseEntity
    {
        public int SoftwareLicenseId { get; set; }
        public int? AssetId { get; set; } // Allocated to Device
        public int? UserId { get; set; } // Allocated to User
        public DateTime AllocatedDate { get; set; }
    }
}
