using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Vendors 
{ 
    public class VendorServiceUpdateTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly VendorService _service;

        public VendorServiceUpdateTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new VendorService(_mockUow.Object);
        }

        [Fact] 
        public async Task UpdateVendor_UpdatesEntity() 
        { 
            var repo = new Mock<IRepository<Vendor>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Vendor { Id = 1, Name = "Old" });
            _mockUow.Setup(u => u.Repository<Vendor>()).Returns(repo.Object);
            
            await _service.UpdateVendorAsync(1, new VendorDto { Name = "New" });
            
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
