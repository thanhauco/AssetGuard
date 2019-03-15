using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Analytics
{
    public class AnalyticsServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly AnalyticsService _service;

        public AnalyticsServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new AnalyticsService(_mockUow.Object);
        }

        [Fact]
        public async Task GenerateForecast_CreatesEntity()
        {
            var asset = new Asset { Id = 1, PurchaseDate = DateTime.Now.AddYears(-3), PurchasePrice = 1000 };
            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            var maintRepo = new Mock<IRepository<MaintenanceRecord>>();
            maintRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<MaintenanceRecord>());

            var forecastRepo = new Mock<IRepository<AssetForecast>>();

            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<MaintenanceRecord>()).Returns(maintRepo.Object);
            _mockUow.Setup(u => u.Repository<AssetForecast>()).Returns(forecastRepo.Object);

            var result = await _service.GenerateForecastAsync(1);

            Assert.Equal(1, result.AssetId);
            forecastRepo.Verify(r => r.AddAsync(It.IsAny<AssetForecast>()), Times.Once);
        }

        [Fact]
        public async Task CalculateUtilization_ReturnsMetric()
        {
            var assignRepo = new Mock<IRepository<Assignment>>();
            assignRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Assignment>
            {
                new Assignment { AssetId = 1 },
                new Assignment { AssetId = 1 }
            });

            var metricRepo = new Mock<IRepository<UtilizationMetric>>();
            _mockUow.Setup(u => u.Repository<Assignment>()).Returns(assignRepo.Object);
            _mockUow.Setup(u => u.Repository<UtilizationMetric>()).Returns(metricRepo.Object);

            var result = await _service.CalculateUtilizationAsync(1, 30);

            Assert.Equal(30, result.PeriodDays);
            Assert.Equal(2, result.TotalAssignments);
        }
    }
}
