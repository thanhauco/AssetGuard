using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class VendorPortalService : IVendorPortalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendorPortalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestForProposal> CreateRfpAsync(RequestForProposal rfp)
        {
            rfp.ReferenceNumber = $"RFP-{DateTime.UtcNow.Year}-{new Random().Next(1000, 9999)}";
            await _unitOfWork.Repository<RequestForProposal>().AddAsync(rfp);
            await _unitOfWork.CompleteAsync();
            return rfp;
        }

        public async Task<IEnumerable<RequestForProposal>> GetOpenRfpsAsync()
        {
            var all = await _unitOfWork.Repository<RequestForProposal>().GetAllAsync();
            return all.Where(r => r.Status == RfpStatus.Open && r.DueDate > DateTime.UtcNow);
        }

        public async Task<VendorBid> SubmitBidAsync(int rfpId, int vendorId, decimal amount, string proposalUrl)
        {
            var bid = new VendorBid
            {
                RfpId = rfpId,
                VendorId = vendorId,
                BidAmount = amount,
                ProposalDocUrl = proposalUrl
            };
            await _unitOfWork.Repository<VendorBid>().AddAsync(bid);
            await _unitOfWork.CompleteAsync();
            return bid;
        }

        public async Task<IEnumerable<VendorBid>> GetBidsForRfpAsync(int rfpId)
        {
            var all = await _unitOfWork.Repository<VendorBid>().GetAllAsync();
            return all.Where(b => b.RfpId == rfpId);
        }

        public async Task AwardBidAsync(int rfpId, int bidId, string notes)
        {
            var rfp = await _unitOfWork.Repository<RequestForProposal>().GetByIdAsync(rfpId);
            rfp.Status = RfpStatus.Awarded;

            var bid = await _unitOfWork.Repository<VendorBid>().GetByIdAsync(bidId);
            bid.IsSelected = true;
            bid.SelectionNotes = notes;

            await _unitOfWork.CompleteAsync();
        }

        public async Task<VendorPortalUser> AuthenticateVendorAsync(string username, string password)
        {
            // Simplified authentication simulation
            var all = await _unitOfWork.Repository<VendorPortalUser>().GetAllAsync();
            return all.FirstOrDefault(u => u.Username == username && u.IsActive);
        }

        public async Task<VendorPortalUser> CreateVendorUserAsync(VendorPortalUser user, string password)
        {
            user.PasswordHash = "hashed_password_simulation"; 
            await _unitOfWork.Repository<VendorPortalUser>().AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }
    }
}
