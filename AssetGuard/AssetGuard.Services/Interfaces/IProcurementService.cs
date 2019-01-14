using System.Collections.Generic;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Services.Interfaces
{
    public interface IProcurementService
    {
        Task<PurchaseRequest> CreateRequestAsync(PurchaseRequestDto dto);
        Task<PurchaseRequest> GetRequestByIdAsync(int id);
        Task<IEnumerable<PurchaseRequest>> GetPendingRequestsAsync();
        Task ApproveRequestAsync(int requestId, int approverId);
        Task RejectRequestAsync(int requestId, int approverId, string reason);
        
        Task<Quote> AddQuoteAsync(QuoteDto dto);
        Task<IEnumerable<Quote>> GetQuotesForRequestAsync(int requestId);
        Task SelectQuoteAsync(int quoteId);
        
        Task<PurchaseOrder> CreateOrderAsync(PurchaseOrderDto dto);
        Task<PurchaseOrder> GetOrderByIdAsync(int id);
        Task MarkOrderReceivedAsync(int orderId, IEnumerable<int> assetIds);
    }
}
