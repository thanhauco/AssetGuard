using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Vendor : BaseEntity
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        
        public ICollection<Contract> Contracts { get; set; }
    }

    public enum VerificationStatus
    {
        Pending,
        Verified,
        Rejected
    }
}
