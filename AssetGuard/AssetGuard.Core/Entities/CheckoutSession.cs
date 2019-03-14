using System;

namespace AssetGuard.Core.Entities
{
    public enum CheckoutStatus
    {
        Active,
        Returned,
        Overdue,
        Lost
    }

    public class CheckoutSession : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime CheckoutTime { get; set; } = DateTime.UtcNow;
        public DateTime? ExpectedReturnTime { get; set; }
        public DateTime? ActualReturnTime { get; set; }
        public CheckoutStatus Status { get; set; } = CheckoutStatus.Active;
        public string CheckoutLocation { get; set; }
        public string ReturnLocation { get; set; }
        public string ConditionAtCheckout { get; set; }
        public string ConditionAtReturn { get; set; }
        public string Notes { get; set; }
        public string DeviceId { get; set; }  // Mobile device that performed checkout
        public bool IsSynced { get; set; } = true;
    }
}
