using System;

namespace AssetGuard.Core.Entities
{
    public class MaintenanceRecord : BaseEntity
    {
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string ServiceProvider { get; set; }
    }
}
