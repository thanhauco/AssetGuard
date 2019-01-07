using System;

namespace AssetGuard.Core.Entities
{
    public class BudgetCode : BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public int FiscalYear { get; set; }
        public bool IsActive { get; set; } = true;
        
        public decimal RemainingAmount => AllocatedAmount - SpentAmount;
    }
}
