using System;

namespace AssetGuard.Core.Entities
{
    public class DirectoryMapping : BaseEntity
    {
        public string Name { get; set; }
        public string DirectoryType { get; set; }  // LDAP, AzureAD, Okta
        public string ServerUrl { get; set; }
        public string BaseDn { get; set; }
        public string BindUsername { get; set; }
        public string BindPasswordEncrypted { get; set; }
        public string UserFilter { get; set; }
        public string GroupFilter { get; set; }
        public string FieldMappings { get; set; }  // JSON
        public bool IsActive { get; set; } = true;
        public int SyncIntervalMinutes { get; set; } = 60;
        public DateTime? LastSyncAt { get; set; }
    }

    public class DirectorySyncLog : BaseEntity
    {
        public int DirectoryMappingId { get; set; }
        public DirectoryMapping DirectoryMapping { get; set; }
        public DateTime SyncStartedAt { get; set; }
        public DateTime? SyncCompletedAt { get; set; }
        public string Status { get; set; }
        public int UsersCreated { get; set; }
        public int UsersUpdated { get; set; }
        public int UsersDisabled { get; set; }
        public int Errors { get; set; }
        public string ErrorLog { get; set; }
    }

    public class ExternalTicket : BaseEntity
    {
        public string ExternalSystem { get; set; }  // ServiceNow, Jira, Zendesk
        public string ExternalTicketId { get; set; }
        public string TicketUrl { get; set; }
        public int? AssetId { get; set; }
        public Asset Asset { get; set; }
        public int? IssueId { get; set; }
        public Issue Issue { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastSyncAt { get; set; }
    }

    public class ImportTemplate : BaseEntity
    {
        public string Name { get; set; }
        public string EntityType { get; set; }  // Asset, Employee, Vendor
        public string FileFormat { get; set; }  // CSV, Excel
        public string ColumnMappings { get; set; }  // JSON
        public string ValidationRules { get; set; }  // JSON
        public bool HasHeaderRow { get; set; } = true;
        public string Delimiter { get; set; } = ",";
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class ImportJob : BaseEntity
    {
        public int TemplateId { get; set; }
        public ImportTemplate Template { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public string Status { get; set; }
        public int TotalRows { get; set; }
        public int SuccessRows { get; set; }
        public int FailedRows { get; set; }
        public string ErrorLogUrl { get; set; }
        public int StartedById { get; set; }
    }
}
