using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;
using Newtonsoft.Json;

namespace AssetGuard.Services.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuditLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task LogAsync(AuditAction action, string entityType, int? entityId, string entityName, object oldValues, object newValues, int? userId)
        {
            var log = new AuditLog
            {
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                EntityName = entityName,
                OldValues = oldValues != null ? JsonConvert.SerializeObject(oldValues) : null,
                NewValues = newValues != null ? JsonConvert.SerializeObject(newValues) : null,
                UserId = userId
            };

            await _unitOfWork.Repository<AuditLog>().AddAsync(log);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsForEntityAsync(string entityType, int entityId)
        {
            var all = await _unitOfWork.Repository<AuditLog>().GetAllAsync();
            return all.Where(l => l.EntityType == entityType && l.EntityId == entityId)
                      .OrderByDescending(l => l.Timestamp);
        }

        public async Task<IEnumerable<AuditLog>> GetLogsForUserAsync(int userId)
        {
            var all = await _unitOfWork.Repository<AuditLog>().GetAllAsync();
            return all.Where(l => l.UserId == userId).OrderByDescending(l => l.Timestamp);
        }

        public async Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count)
        {
            var all = await _unitOfWork.Repository<AuditLog>().GetAllAsync();
            return all.OrderByDescending(l => l.Timestamp).Take(count);
        }

        public async Task<IEnumerable<AuditLog>> SearchLogsAsync(string searchTerm, AuditAction? action, DateTime? fromDate, DateTime? toDate)
        {
            var all = await _unitOfWork.Repository<AuditLog>().GetAllAsync();
            var query = all.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(l => l.EntityName.Contains(searchTerm) || l.UserName.Contains(searchTerm));
            if (action.HasValue)
                query = query.Where(l => l.Action == action.Value);
            if (fromDate.HasValue)
                query = query.Where(l => l.Timestamp >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(l => l.Timestamp <= toDate.Value);

            return query.OrderByDescending(l => l.Timestamp);
        }
    }
}
