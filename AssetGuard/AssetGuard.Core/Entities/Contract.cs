using System;

namespace AssetGuard.Core.Entities
{
    public class Contract : BaseEntity
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
