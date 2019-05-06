using System;
using System.Collections.Generic;

namespace AssetGuard.Core.Entities
{
    public enum WorkOrderStatus
    {
        Open,
        Scheduled,
        InProgress,
        OnHold,
        WaitingForParts,
        Completed,
        Cancelled
    }

    public enum WorkOrderPriority
    {
        Low,
        Medium,
        High,
        Critical,
        Emergency
    }

    public class WorkOrder : BaseEntity
    {
        public string TicketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int? RequestedById { get; set; }
        public Employee RequestedBy { get; set; }
        public int? AssignedTechnicianId { get; set; }
        public Employee AssignedTechnician { get; set; }
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Medium;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ScheduledDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int? SlaId { get; set; }
        public ServiceLevelAgreement Sla { get; set; }
        public decimal TotalCost { get; set; }
        public int TotalHoursLogged { get; set; }
        public ICollection<WorkOrderTask> Tasks { get; set; }
    }

    public class WorkOrderTask : BaseEntity
    {
        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        public int? CompletedById { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal ActualHours { get; set; }
    }

    public class ServiceLevelAgreement : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriorityLevel { get; set; }
        public int ResponseTimeHours { get; set; }
        public int ResolutionTimeHours { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IncludeWeekends { get; set; } = false;
        public string BusinessHoursStart { get; set; } // "09:00"
        public string BusinessHoursEnd { get; set; }   // "17:00"
    }
}
