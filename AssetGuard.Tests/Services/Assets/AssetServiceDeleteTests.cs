using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;

namespace AssetGuard.Tests.Services.Assets 
{ 
    public class AssetServiceDeleteTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AssetService _service;

        public AssetServiceDeleteTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AssetService(_mockUow.Object);
        }

        [Fact] 
        public async Task DeleteAsset_RemovesEntity() 
        { 
            var repo = new Mock<IRepository<Asset>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Asset { Id = 1 });
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(repo.Object);
            
            await _service.DeleteAssetAsync(1);
            
            repo.Verify(r => r.Delete(It.Is<Asset>(a => a.Id == 1)), Times.Once);
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
