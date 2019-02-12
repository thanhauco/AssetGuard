using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Transfers
{
    public class TransferServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly TransferService _service;

        public TransferServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new TransferService(_mockUow.Object);
        }

        [Fact]
        public async Task InitiateTransfer_AddsEntity()
        {
            var repo = new Mock<IRepository<AssetTransfer>>();
            _mockUow.Setup(u => u.Repository<AssetTransfer>()).Returns(repo.Object);

            await _service.InitiateTransferAsync(new CreateTransferDto { TransferType = "LocationChange" });

            repo.Verify(r => r.AddAsync(It.IsAny<AssetTransfer>()), Times.Once);
        }

        [Fact]
        public async Task CompleteTransfer_SetsCompleted()
        {
            var transfer = new AssetTransfer { Id = 1, AssetId = 1, IsCompleted = false };
            var asset = new Asset { Id = 1 };
            
            var tRepo = new Mock<IRepository<AssetTransfer>>();
            tRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(transfer);
            var aRepo = new Mock<IRepository<Asset>>();
            aRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            _mockUow.Setup(u => u.Repository<AssetTransfer>()).Returns(tRepo.Object);
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(aRepo.Object);

            await _service.CompleteTransferAsync(1);

            Assert.True(transfer.IsCompleted);
        }
    }
}
