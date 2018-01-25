using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.AdvancedAssets
{
    public class LicenseServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly LicenseService _service;

        public LicenseServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new LicenseService(_mockUow.Object);
        }

        [Fact]
        public async Task GetAllLicenses_ReturnsList()
        {
            var repo = new Mock<IRepository<SoftwareLicense>>();
            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<SoftwareLicense>());
            _mockUow.Setup(u => u.Repository<SoftwareLicense>()).Returns(repo.Object);
            
            var result = await _service.GetAllLicensesAsync();
            Assert.Empty(result);
        }
    }
}
