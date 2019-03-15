using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Checkout
{
    public class CheckoutServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CheckoutService _service;

        public CheckoutServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new CheckoutService(_mockUow.Object);
        }

        [Fact]
        public async Task CheckoutAsset_CreatesSession()
        {
            var asset = new Asset { Id = 1, Status = AssetStatus.Available };
            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            var sessionRepo = new Mock<IRepository<CheckoutSession>>();

            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<CheckoutSession>()).Returns(sessionRepo.Object);

            var result = await _service.CheckoutAssetAsync(1, 1, "device1", "Good");

            Assert.Equal(CheckoutStatus.Active, result.Status);
            Assert.Equal(AssetStatus.Assigned, asset.Status);
            sessionRepo.Verify(r => r.AddAsync(It.IsAny<CheckoutSession>()), Times.Once);
        }

        [Fact]
        public async Task ReturnAsset_UpdatesSession()
        {
            var asset = new Asset { Id = 1, Status = AssetStatus.Assigned };
            var session = new CheckoutSession { Id = 1, AssetId = 1, Status = CheckoutStatus.Active };

            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            var sessionRepo = new Mock<IRepository<CheckoutSession>>();
            sessionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(session);

            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<CheckoutSession>()).Returns(sessionRepo.Object);

            var result = await _service.ReturnAssetAsync(1, "Good", "No issues");

            Assert.Equal(CheckoutStatus.Returned, result.Status);
            Assert.Equal(AssetStatus.Available, asset.Status);
        }
    }
}
