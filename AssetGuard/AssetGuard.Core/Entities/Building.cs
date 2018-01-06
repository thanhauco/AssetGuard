using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }
        
        public ICollection<Room> Rooms { get; set; }
    }
}
