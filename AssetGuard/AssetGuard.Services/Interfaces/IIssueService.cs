using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IIssueService
    {
        Task<IssueDto> ReportIssueAsync(CreateIssueDto dto);
        Task<IEnumerable<IssueDto>> GetOpenIssuesAsync();
        Task ResolveIssueAsync(int issueId);
    }
}
