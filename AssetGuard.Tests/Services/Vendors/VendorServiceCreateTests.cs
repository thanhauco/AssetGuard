using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Vendors 
{ 
    public class VendorServiceCreateTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly VendorService _service;

        public VendorServiceCreateTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new VendorService(_mockUow.Object);
        }

        [Fact] 
        public async Task CreateVendor_AddsEntity() 
        { 
            var repo = new Mock<IRepository<Vendor>>();
            _mockUow.Setup(u => u.Repository<Vendor>()).Returns(repo.Object);
            
            await _service.CreateVendorAsync(new VendorDto { Name = "Acme" });
            
            repo.Verify(r => r.AddAsync(It.Is<Vendor>(v => v.Name == "Acme")), Times.Once);
        } 
    } 
}
