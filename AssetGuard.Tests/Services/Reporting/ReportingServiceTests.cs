using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Reporting
{
    public class ReportingServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly ReportingService _service;

        public ReportingServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new ReportingService(_mockUow.Object);
        }

        [Fact]
        public async Task GetDashboardMetrics_ReturnsCorrectCounts()
        {
            var assetsReq = new Mock<IRepository<Asset>>();
            assetsReq.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Asset> { new Asset(), new Asset() });
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetsReq.Object);
            
            // Simplified mocking for brevity, assume other repos return empty list by default mock behavior if loose
            // But strict mock needs setup. Setting just Asset for now.
            var issueRepo = new Mock<IRepository<Issue>>();
            issueRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Issue, bool>>>()))
                .ReturnsAsync(new List<Issue>());
            _mockUow.Setup(u => u.Repository<Issue>()).Returns(issueRepo.Object);

            var contractRepo = new Mock<IRepository<Contract>>();
            contractRepo.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<Contract, bool>>>()))
                .ReturnsAsync(new List<Contract>());
            _mockUow.Setup(u => u.Repository<Contract>()).Returns(contractRepo.Object);

            var result = await _service.GetDashboardMetricsAsync();
            Assert.Equal(2, result.TotalAssets);
        }
    }
}
