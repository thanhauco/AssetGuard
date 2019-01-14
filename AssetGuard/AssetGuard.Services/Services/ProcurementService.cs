using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using AssetGuard.Services.Interfaces;

namespace AssetGuard.Services.Services
{
    public class ProcurementService : IProcurementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcurementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseRequest> CreateRequestAsync(PurchaseRequestDto dto)
        {
            var request = new PurchaseRequest
            {
                Title = dto.Title,
                Description = dto.Description,
                RequestedById = dto.RequestedById,
                CategoryId = dto.CategoryId,
                Quantity = dto.Quantity,
                EstimatedUnitCost = dto.EstimatedUnitCost,
                BudgetCodeId = dto.BudgetCodeId,
                Justification = dto.Justification,
                Status = PurchaseRequestStatus.Submitted
            };

            await _unitOfWork.Repository<PurchaseRequest>().AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return request;
        }

        public async Task<PurchaseRequest> GetRequestByIdAsync(int id)
        {
            return await _unitOfWork.Repository<PurchaseRequest>().GetByIdAsync(id);
        }

        public async Task<IEnumerable<PurchaseRequest>> GetPendingRequestsAsync()
        {
            var all = await _unitOfWork.Repository<PurchaseRequest>().GetAllAsync();
            return all.Where(r => r.Status == PurchaseRequestStatus.Submitted);
        }

        public async Task ApproveRequestAsync(int requestId, int approverId)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.Status = PurchaseRequestStatus.Approved;
            request.ApprovedById = approverId;
            request.ApprovedDate = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();
        }

        public async Task RejectRequestAsync(int requestId, int approverId, string reason)
        {
            var request = await GetRequestByIdAsync(requestId);
            request.Status = PurchaseRequestStatus.Rejected;
            request.ApprovedById = approverId;
            request.RejectionReason = reason;
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Quote> AddQuoteAsync(QuoteDto dto)
        {
            var quote = new Quote
            {
                PurchaseRequestId = dto.PurchaseRequestId,
                VendorId = dto.VendorId,
                QuoteNumber = dto.QuoteNumber,
                UnitPrice = dto.UnitPrice,
                TotalPrice = dto.TotalPrice,
                LeadTimeDays = dto.LeadTimeDays,
                ValidUntil = dto.ValidUntil,
                Notes = dto.Notes,
                Status = QuoteStatus.Received
            };

            await _unitOfWork.Repository<Quote>().AddAsync(quote);
            await _unitOfWork.CompleteAsync();
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetQuotesForRequestAsync(int requestId)
        {
            var all = await _unitOfWork.Repository<Quote>().GetAllAsync();
            return all.Where(q => q.PurchaseRequestId == requestId);
        }

        public async Task SelectQuoteAsync(int quoteId)
        {
            var quote = await _unitOfWork.Repository<Quote>().GetByIdAsync(quoteId);
            quote.Status = QuoteStatus.Selected;
            
            var otherQuotes = await GetQuotesForRequestAsync(quote.PurchaseRequestId);
            foreach (var other in otherQuotes.Where(q => q.Id != quoteId))
            {
                other.Status = QuoteStatus.Rejected;
            }
            
            await _unitOfWork.CompleteAsync();
        }

        public async Task<PurchaseOrder> CreateOrderAsync(PurchaseOrderDto dto)
        {
            var order = new PurchaseOrder
            {
                PoNumber = dto.PoNumber ?? $"PO-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}",
                PurchaseRequestId = dto.PurchaseRequestId,
                VendorId = dto.VendorId,
                SelectedQuoteId = dto.SelectedQuoteId,
                BudgetCodeId = dto.BudgetCodeId,
                TotalAmount = dto.TotalAmount,
                ExpectedDeliveryDate = dto.ExpectedDeliveryDate,
                ShippingAddress = dto.ShippingAddress,
                Notes = dto.Notes,
                Status = PurchaseOrderStatus.Sent
            };

            await _unitOfWork.Repository<PurchaseOrder>().AddAsync(order);

            var request = await GetRequestByIdAsync(dto.PurchaseRequestId);
            request.Status = PurchaseRequestStatus.Ordered;

            await _unitOfWork.CompleteAsync();
            return order;
        }

        public async Task<PurchaseOrder> GetOrderByIdAsync(int id)
        {
            return await _unitOfWork.Repository<PurchaseOrder>().GetByIdAsync(id);
        }

        public async Task MarkOrderReceivedAsync(int orderId, IEnumerable<int> assetIds)
        {
            var order = await GetOrderByIdAsync(orderId);
            order.Status = PurchaseOrderStatus.Received;
            order.ActualDeliveryDate = DateTime.UtcNow;

            var request = await GetRequestByIdAsync(order.PurchaseRequestId);
            request.Status = PurchaseRequestStatus.Received;

            await _unitOfWork.CompleteAsync();
        }
    }
}
