using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditAction action, string entityType, int? entityId, string entityName, object oldValues, object newValues, int? userId);
        Task<IEnumerable<AuditLog>> GetLogsForEntityAsync(string entityType, int entityId);
        Task<IEnumerable<AuditLog>> GetLogsForUserAsync(int userId);
        Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count);
        Task<IEnumerable<AuditLog>> SearchLogsAsync(string searchTerm, AuditAction? action, System.DateTime? fromDate, System.DateTime? toDate);
    }
}
