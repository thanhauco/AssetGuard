using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public class Asset : BaseEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchasePrice { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    }
}
