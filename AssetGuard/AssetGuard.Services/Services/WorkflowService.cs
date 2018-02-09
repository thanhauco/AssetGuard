using System;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkflowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> SubmitRequestAsync(SubmitApprovalDto dto, int requesterId)
        {
            var workflows = await _unitOfWork.Repository<Workflow>().FindAsync(w => w.Name == dto.WorkflowName);
            var workflow = workflows.FirstOrDefault();
            
            if (workflow == null) throw new Exception("Workflow not found"); // Should use NotFoundException
            
            // Assuming steps loaded or we fetch them
            // For MVP, just creating request
            var request = new ApprovalRequest
            {
                WorkflowId = workflow.Id,
                CurrentStepId = 0, // Needs step logic
                Status = "Pending",
                RequesterUserId = requesterId,
                RequestData = dto.RequestDetails
            };

            await _unitOfWork.Repository<ApprovalRequest>().AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return request.Id;
        }

        public async Task ProcessApprovalAsync(ApprovalActionDto dto, int approverId)
        {
            var request = await _unitOfWork.Repository<ApprovalRequest>().GetByIdAsync(dto.RequestId);
            if (request == null) return;

            request.Status = dto.IsApproved ? "Approved" : "Rejected";
            
            var log = new ApprovalLog
            {
                ApprovalRequestId = request.Id,
                ApproverUserId = approverId,
                Action = dto.IsApproved ? "Approve" : "Reject",
                Comments = dto.Comments,
                ActionDate = DateTime.UtcNow
            };

            await _unitOfWork.Repository<ApprovalRequest>().UpdateAsync(request);
            await _unitOfWork.Repository<ApprovalLog>().AddAsync(log);
            await _unitOfWork.CompleteAsync();
        }
    }
}
