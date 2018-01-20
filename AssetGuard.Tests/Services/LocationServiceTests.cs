using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Services
{
    public class LocationServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly LocationService _service;

        public LocationServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new LocationService(_mockUow.Object);
        }

        [Fact]
        public async Task GetSite_ReturnsNull_WhenNotFound()
        {
            var repoMock = new Mock<IRepository<Site>>();
            _mockUow.Setup(u => u.Repository<Site>()).Returns(repoMock.Object);

            var result = await _service.GetSiteByIdAsync(999);
            Assert.Null(result);
        }
    }
}
