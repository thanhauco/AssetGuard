using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services
{
    public class MaintenanceServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly MaintenanceService _service;

        public MaintenanceServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new MaintenanceService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetHistory_ReturnsEmpty_WhenNoRecords()
        {
            var assetId = 1;
            var repoMock = new Mock<IRepository<MaintenanceRecord>>();
            repoMock.Setup(r => r.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<MaintenanceRecord, bool>>>()))
                .ReturnsAsync(new List<MaintenanceRecord>());
            
            _mockUnitOfWork.Setup(u => u.Repository<MaintenanceRecord>()).Returns(repoMock.Object);

            var result = await _service.GetMaintenanceHistoryAsync(assetId);

            Assert.Empty(result);
        }
    }
}
