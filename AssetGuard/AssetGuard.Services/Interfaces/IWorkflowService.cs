using System.Threading.Tasks;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IWorkflowService
    {
        Task<int> SubmitRequestAsync(SubmitApprovalDto dto, int requesterId);
        Task ProcessApprovalAsync(ApprovalActionDto dto, int approverId);
    }
}
