using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IDisposalService
    {
        Task<DisposalRequest> CreateRequestAsync(int assetId, DisposalMethod method, int requestedById, string justification);
        Task<DisposalRequest> GetRequestByIdAsync(int id);
        Task<IEnumerable<DisposalRequest>> GetPendingRequestsAsync();
        Task ApproveRequestAsync(int requestId, int approvedById);
        Task RejectRequestAsync(int requestId, int rejectedById, string reason);
        Task CompleteDisposalAsync(int requestId, decimal actualSalvageValue, string recipientInfo);
        
        Task<DisposalCertificate> GenerateCertificateAsync(int disposalRequestId, string issuedBy);
        Task MarkDataWipeCompleteAsync(int requestId, string certificateUrl);
    }
}
