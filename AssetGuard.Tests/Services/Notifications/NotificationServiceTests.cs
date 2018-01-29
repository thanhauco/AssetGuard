using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Notifications
{
    public class NotificationServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly NotificationService _service;

        public NotificationServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new NotificationService(_mockUow.Object);
        }

        [Fact]
        public async Task SendAsync_SavesNotification()
        {
            var repo = new Mock<IRepository<Notification>>();
            _mockUow.Setup(u => u.Repository<Notification>()).Returns(repo.Object);
            
            await _service.SendAsync(new SendNotificationDto());
            
            repo.Verify(r => r.AddAsync(It.IsAny<Notification>()), Times.Once);
        }
    }
}
