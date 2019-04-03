using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class DisposalService : IDisposalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisposalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DisposalRequest> CreateRequestAsync(int assetId, DisposalMethod method, int requestedById, string justification)
        {
            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(assetId);
            
            var request = new DisposalRequest
            {
                AssetId = assetId,
                Method = method,
                RequestedById = requestedById,
                Justification = justification,
                EstimatedSalvageValue = asset.PurchasePrice * 0.1m
            };

            await _unitOfWork.Repository<DisposalRequest>().AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return request;
        }

        public async Task<DisposalRequest> GetRequestByIdAsync(int id)
        {
            return await _unitOfWork.Repository<DisposalRequest>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<DisposalRequest>> GetPendingRequestsAsync()
        {
            var all = await _unitOfWork.Repository<DisposalRequest>().GetAllAsync();
            return all.Where(r => r.Status == DisposalStatus.Pending);
        }

        public async Task ApproveRequestAsync(int requestId, int approvedById)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.Status = DisposalStatus.Approved;
            request.ApprovedById = approvedById;
            request.ApprovalDate = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task RejectRequestAsync(int requestId, int rejectedById, string reason)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.Status = DisposalStatus.Cancelled;
            request.Notes = reason;
            await _unitOfWork.CompleteAsync();
        }

        public async Task CompleteDisposalAsync(int requestId, decimal actualSalvageValue, string recipientInfo)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.Status = DisposalStatus.Completed;
            request.ActualSalvageValue = actualSalvageValue;
            request.RecipientInfo = recipientInfo;
            request.CompletedDate = DateTime.UtcNow;

            var asset = await _unitOfWork.Repository<Asset>().GetByIdAsync(request.AssetId);
            asset.Status = AssetStatus.Retired;

            await _unitOfWork.CompleteAsync();
        }

        public async Task<DisposalCertificate> GenerateCertificateAsync(int disposalRequestId, string issuedBy)
        {
            var cert = new DisposalCertificate
            {
                DisposalRequestId = disposalRequestId,
                CertificateNumber = $"DISP-{DateTime.UtcNow:yyyyMMdd}-{disposalRequestId}",
                IssuedBy = issuedBy
            };

            await _unitOfWork.Repository<DisposalCertificate>().AddAsync(cert);
            await _unitOfWork.CompleteAsync();
            return cert;
        }

        public async Task MarkDataWipeCompleteAsync(int requestId, string certificateUrl)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.DataWipeCompleted = true;
            request.DataWipeCertificateUrl = certificateUrl;
            await _unitOfWork.CompleteAsync();
        }
    }
}
