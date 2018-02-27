using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using AssetGuard.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IIdentityService> _mockService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockService = new Mock<IIdentityService>();
            _controller = new AuthController(_mockService.Object);
        }

        [Fact]
        public async Task Login_ReturnsOk_WhenValid()
        {
            _mockService.Setup(s => s.LoginAsync(It.IsAny<LoginRequest>())).ReturnsAsync(new LoginResponse());
            var result = await _controller.Login(new LoginRequest { Username = "u", Password = "p" });
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
