using System;

namespace AssetGuard.Core.Entities
{
    public enum AlertSeverity
    {
        Info,
        Warning,
        Error,
        Critical
    }

    public enum AlertType
    {
        MaintenanceDue,
        WarrantyExpiring,
        InsuranceExpiring,
        LicenseExpiring,
        ComplianceCheck,
        EndOfLife,
        OverdueCheckout,
        LowStock,
        BudgetThreshold,
        AuditRequired
    }

    public class AlertRule : BaseEntity
    {
        public string Name { get; set; }
        public AlertType Type { get; set; }
        public AlertSeverity Severity { get; set; }
        public bool IsActive { get; set; } = true;
        public int TriggerDaysBefore { get; set; } = 30;
        public string Condition { get; set; }
        public string NotificationChannels { get; set; }  // Email, SMS, InApp
        public int? CategoryId { get; set; }
        public string RecipientRoles { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Alert : BaseEntity
    {
        public int AlertRuleId { get; set; }
        public AlertRule Rule { get; set; }
        public int? AssetId { get; set; }
        public Asset Asset { get; set; }
        public AlertSeverity Severity { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime TriggeredAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
        public bool IsDismissed { get; set; } = false;
        public DateTime? DismissedAt { get; set; }
        public int? DismissedById { get; set; }
        public string ActionUrl { get; set; }
    }
}
