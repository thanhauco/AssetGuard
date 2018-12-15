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
        private readonly Mock<IIdentityService> _mock;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mock = new Mock<IIdentityService>();
            _controller = new AuthController(_mock.Object);
        }

        [Fact] 
        public async Task Login_ReturnsOk_WhenValid() 
        { 
            _mock.Setup(s => s.LoginAsync(It.IsAny<LoginRequest>())).ReturnsAsync(new LoginResponse { Token = "JWT" });
            
            var result = await _controller.Login(new LoginRequest());
            
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Register_ReturnsOk()
        {
            _mock.Setup(s => s.RegisterAsync(It.IsAny<LoginRequest>())).ReturnsAsync(new LoginResponse());
            
            var result = await _controller.Register(new LoginRequest());
            
            Assert.IsType<OkObjectResult>(result);
        }
    } 
}
