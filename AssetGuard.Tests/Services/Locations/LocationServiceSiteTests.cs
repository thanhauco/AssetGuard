using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Locations 
{ 
    public class LocationServiceSiteTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly LocationService _service;

        public LocationServiceSiteTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new LocationService(_mockUow.Object);
        }

        [Fact] 
        public async Task GetAllSites_ReturnsList() 
        { 
            var repo = new Mock<IRepository<Site>>();
            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Site> { new Site() });
            _mockUow.Setup(u => u.Repository<Site>()).Returns(repo.Object);
            
            var result = await _service.GetAllSitesAsync();
            
            Assert.NotEmpty(result);
        } 
    } 
}
