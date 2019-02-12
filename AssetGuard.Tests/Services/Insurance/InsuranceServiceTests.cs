using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Insurance
{
    public class InsuranceServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly InsuranceService _service;

        public InsuranceServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new InsuranceService(_mockUow.Object);
        }

        [Fact]
        public async Task AddWarranty_AddsEntity()
        {
            var repo = new Mock<IRepository<Warranty>>();
            _mockUow.Setup(u => u.Repository<Warranty>()).Returns(repo.Object);

            await _service.AddWarrantyAsync(new WarrantyDto { Type = "Manufacturer" });

            repo.Verify(r => r.AddAsync(It.IsAny<Warranty>()), Times.Once);
        }

        [Fact]
        public async Task CalculateTotalCoverage_SumsActive()
        {
            var warranties = new List<Warranty>
            {
                new Warranty { AssetId = 1, CoverageAmount = 1000, StartDate = DateTime.Now.AddDays(-10), EndDate = DateTime.Now.AddDays(10) }
            };
            var policies = new List<InsurancePolicy>
            {
                new InsurancePolicy { AssetId = 1, CoverageLimit = 5000, EffectiveDate = DateTime.Now.AddDays(-10), ExpirationDate = DateTime.Now.AddDays(10) }
            };

            var wRepo = new Mock<IRepository<Warranty>>();
            wRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(warranties);
            var pRepo = new Mock<IRepository<InsurancePolicy>>();
            pRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(policies);

            _mockUow.Setup(u => u.Repository<Warranty>()).Returns(wRepo.Object);
            _mockUow.Setup(u => u.Repository<InsurancePolicy>()).Returns(pRepo.Object);

            var total = await _service.CalculateTotalCoverageAsync(1);

            Assert.Equal(6000, total);
        }
    }
}
