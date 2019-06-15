using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;

namespace AssetGuard.Services.Interfaces
{
    public interface IVendorPortalService
    {
        Task<RequestForProposal> CreateRfpAsync(RequestForProposal rfp);
        Task<IEnumerable<RequestForProposal>> GetOpenRfpsAsync();
        
        Task<VendorBid> SubmitBidAsync(int rfpId, int vendorId, decimal amount, string proposalUrl);
        Task<IEnumerable<VendorBid>> GetBidsForRfpAsync(int rfpId);
        
        Task AwardBidAsync(int rfpId, int bidId, string notes);
        
        Task<VendorPortalUser> AuthenticateVendorAsync(string username, string password);
        Task<VendorPortalUser> CreateVendorUserAsync(VendorPortalUser user, string password);
    }
}
