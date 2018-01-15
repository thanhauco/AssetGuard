using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class ApplicationRole : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
