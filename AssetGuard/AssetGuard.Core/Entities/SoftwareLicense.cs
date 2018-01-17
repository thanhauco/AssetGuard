using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class SoftwareLicense : BaseEntity
    {
        public string SoftwareName { get; set; }
        public string LicenseKey { get; set; }
        public int Seats { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Cost { get; set; }
        
        public ICollection<LicenseAllocation> Allocations { get; set; }
    }
}
