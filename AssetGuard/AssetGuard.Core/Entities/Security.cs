using System;

namespace AssetGuard.Core.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public ApplicationRole Role { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public bool CanCreate { get; set; }
        public bool CanRead { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExport { get; set; }
    }

    public class SensitiveField : BaseEntity
    {
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public string MaskPattern { get; set; }
        public bool MaskInUI { get; set; } = true;
        public bool MaskInExport { get; set; } = true;
        public bool MaskInLogs { get; set; } = true;
    }

    public class UserSession : BaseEntity
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string SessionToken { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }
        public DateTime LastActivityAt { get; set; } = DateTime.UtcNow;
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class LoginAttempt : BaseEntity
    {
        public string Username { get; set; }
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
        public bool IsSuccessful { get; set; }
        public string FailureReason { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
