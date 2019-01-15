using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Audit
{
    public class InventoryAuditServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly InventoryAuditService _service;

        public InventoryAuditServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new InventoryAuditService(_mockUow.Object);
        }

        [Fact]
        public async Task CreateSession_AddsEntity()
        {
            var sessionRepo = new Mock<IRepository<AuditSession>>();
            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Asset> { new Asset(), new Asset() });
            
            _mockUow.Setup(u => u.Repository<AuditSession>()).Returns(sessionRepo.Object);
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);

            var result = await _service.CreateSessionAsync(new CreateAuditSessionDto { Name = "Q4 Audit" });

            sessionRepo.Verify(r => r.AddAsync(It.Is<AuditSession>(s => s.Name == "Q4 Audit")), Times.Once);
        }

        [Fact]
        public async Task StartSession_UpdatesStatus()
        {
            var session = new AuditSession { Id = 1, Status = AuditSessionStatus.Scheduled };
            var repo = new Mock<IRepository<AuditSession>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(session);
            _mockUow.Setup(u => u.Repository<AuditSession>()).Returns(repo.Object);

            await _service.StartSessionAsync(1);

            Assert.Equal(AuditSessionStatus.InProgress, session.Status);
            Assert.NotNull(session.StartedAt);
        }

        [Fact]
        public async Task RecordScan_DetectsLocationMismatch()
        {
            var asset = new Asset { Id = 1, RoomId = 5 };
            var assetRepo = new Mock<IRepository<Asset>>();
            assetRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(asset);

            var scanRepo = new Mock<IRepository<AuditScan>>();
            var sessionRepo = new Mock<IRepository<AuditSession>>();
            sessionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new AuditSession { Id = 1 });

            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepo.Object);
            _mockUow.Setup(u => u.Repository<AuditScan>()).Returns(scanRepo.Object);
            _mockUow.Setup(u => u.Repository<AuditSession>()).Returns(sessionRepo.Object);

            var result = await _service.RecordScanAsync(new RecordScanDto
            {
                AuditSessionId = 1,
                AssetId = 1,
                FoundInRoomId = 10 // Different from expected room 5
            });

            Assert.True(result.LocationMismatch);
        }
    }
}
