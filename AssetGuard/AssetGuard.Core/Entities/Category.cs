using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public ICollection<Asset> Assets { get; set; }
    }
}
