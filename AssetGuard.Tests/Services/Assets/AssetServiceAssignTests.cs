using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;

namespace AssetGuard.Tests.Services.Assets 
{ 
    public class AssetServiceAssignTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AssetService _service;

        public AssetServiceAssignTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AssetService(_mockUow.Object);
        }

        [Fact] 
        public async Task AssignAsset_CreatesAssignment() 
        { 
            var aRepo = new Mock<IRepository<Assignment>>();
            var assetRepo = new Mock<IRepository<Asset>>();
            var empRepo = new Mock<IRepository<Employee>>();
            
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Asset { Id = 1, Status = AssetStatus.Available });
            empRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Employee { Id = 1 });
            
            _mockUow.Setup(u => u.Repository<Assignment>()).Returns(aRepo.Object);
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<Employee>()).Returns(empRepo.Object);
            
            await _service.AssignAssetAsync(1, 1);
            
            aRepo.Verify(r => r.AddAsync(It.IsAny<Assignment>()), Times.Once);
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
