using System;

namespace AssetGuard.Core.Entities
{
    public class Assignment : BaseEntity
    {
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Notes { get; set; }
    }
}
