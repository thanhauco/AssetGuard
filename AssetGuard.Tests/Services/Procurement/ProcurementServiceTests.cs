using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Procurement
{
    public class ProcurementServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly ProcurementService _service;

        public ProcurementServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new ProcurementService(_mockUow.Object);
        }

        [Fact]
        public async Task CreateRequest_AddsEntity()
        {
            var repo = new Mock<IRepository<PurchaseRequest>>();
            _mockUow.Setup(u => u.Repository<PurchaseRequest>()).Returns(repo.Object);

            await _service.CreateRequestAsync(new PurchaseRequestDto { Title = "New Laptop" });

            repo.Verify(r => r.AddAsync(It.Is<PurchaseRequest>(p => p.Title == "New Laptop")), Times.Once);
        }

        [Fact]
        public async Task ApproveRequest_SetsApprovedStatus()
        {
            var request = new PurchaseRequest { Id = 1, Status = PurchaseRequestStatus.Submitted };
            var repo = new Mock<IRepository<PurchaseRequest>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(request);
            _mockUow.Setup(u => u.Repository<PurchaseRequest>()).Returns(repo.Object);

            await _service.ApproveRequestAsync(1, 10);

            Assert.Equal(PurchaseRequestStatus.Approved, request.Status);
            Assert.Equal(10, request.ApprovedById);
        }

        [Fact]
        public async Task RejectRequest_SetsRejectedStatus()
        {
            var request = new PurchaseRequest { Id = 1, Status = PurchaseRequestStatus.Submitted };
            var repo = new Mock<IRepository<PurchaseRequest>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(request);
            _mockUow.Setup(u => u.Repository<PurchaseRequest>()).Returns(repo.Object);

            await _service.RejectRequestAsync(1, 10, "Budget exceeded");

            Assert.Equal(PurchaseRequestStatus.Rejected, request.Status);
            Assert.Equal("Budget exceeded", request.RejectionReason);
        }
    }
}
