using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string BadgeNumber { get; set; }

        public ICollection<Assignment> AssetAssignments { get; set; }
    }
}
