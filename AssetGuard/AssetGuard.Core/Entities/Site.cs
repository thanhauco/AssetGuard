using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Site : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public ICollection<Building> Buildings { get; set; }
    }
}
