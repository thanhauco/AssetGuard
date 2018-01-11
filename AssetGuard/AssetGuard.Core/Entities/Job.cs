using System;

namespace AssetGuard.Core.Entities
{
    public class Job : BaseEntity
    {
        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }

        public string TechnicianNotes { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
