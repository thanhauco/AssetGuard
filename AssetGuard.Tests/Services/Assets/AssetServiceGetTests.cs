using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Assets 
{ 
    public class AssetServiceGetTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AssetService _service;

        public AssetServiceGetTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AssetService(_mockUow.Object);
        }

        [Fact] 
        public async Task GetById_ReturnsAsset() 
        { 
            var repo = new Mock<IRepository<Asset>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Asset { Id = 1 });
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(repo.Object);
            
            var result = await _service.GetAssetByIdAsync(1);
            
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        } 
    } 
}
