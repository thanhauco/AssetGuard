using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Assets 
{ 
    public class AssetServiceCreateTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AssetService _service;

        public AssetServiceCreateTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AssetService(_mockUow.Object);
        }

        [Fact] 
        public async Task CreateAsset_AddsEntity() 
        { 
            var repo = new Mock<IRepository<Asset>>();
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(repo.Object);
            
            await _service.CreateAssetAsync(new AssetDto { Name = "Test" });
            
            repo.Verify(r => r.AddAsync(It.Is<Asset>(a => a.Name == "Test")), Times.Once);
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
