using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using AssetGuard.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers
{
    public class AssetsControllerTests
    {
        private readonly Mock<IAssetService> _mockService;
        private readonly AssetsController _controller;

        public AssetsControllerTests()
        {
            _mockService = new Mock<IAssetService>();
            _controller = new AssetsController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            var result = await _controller.Get(1);
            Assert.IsType<OkObjectResult>(result.Result); // Assuming service returns null and not found check is what we test, or modify mock to return obj
        }
    }
}
