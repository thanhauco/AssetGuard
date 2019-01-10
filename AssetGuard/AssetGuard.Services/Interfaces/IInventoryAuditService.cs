using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IInventoryAuditService
    {
        Task<AuditSession> CreateSessionAsync(CreateAuditSessionDto dto);
        Task<AuditSession> GetSessionByIdAsync(int id);
        Task<IEnumerable<AuditSession>> GetActiveSessionsAsync();
        Task StartSessionAsync(int sessionId);
        Task CompleteSessionAsync(int sessionId);
        
        Task<AuditScan> RecordScanAsync(RecordScanDto dto);
        Task<IEnumerable<AuditScan>> GetScansForSessionAsync(int sessionId);
        
        Task<IEnumerable<DiscrepancyReport>> GenerateDiscrepanciesAsync(int sessionId);
        Task ResolveDiscrepancyAsync(ResolveDiscrepancyDto dto);
        
        Task<AuditSummaryDto> GetAuditSummaryAsync(int sessionId);
    }
}
