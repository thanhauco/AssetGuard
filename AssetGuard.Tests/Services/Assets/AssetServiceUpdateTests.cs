using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Assets 
{ 
    public class AssetServiceUpdateTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AssetService _service;

        public AssetServiceUpdateTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AssetService(_mockUow.Object);
        }

        [Fact] 
        public async Task UpdateAsset_UpdatesEntity() 
        { 
            var repo = new Mock<IRepository<Asset>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Asset { Id = 1, Name = "Old" });
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(repo.Object);
            
            await _service.UpdateAssetAsync(1, new AssetDto { Name = "New" });
            
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
