using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Controllers.Notifications
{
    public class NotificationsControllerTests
    {
        private readonly Mock<INotificationService> _mock;
        private readonly NotificationsController _controller;

        public NotificationsControllerTests()
        {
            _mock = new Mock<INotificationService>();
            _controller = new NotificationsController(_mock.Object);
        }

        [Fact]
        public async Task Send_ReturnsOk()
        {
            var res = await _controller.Send(new SendNotificationDto());
            Assert.IsType<OkResult>(res);
        }
    }
}
