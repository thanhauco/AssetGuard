using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers
{
    public class AssignmentsControllerTests
    {
        private readonly Mock<IAssetService> _mockService;
        private readonly AssignmentsController _controller;

        public AssignmentsControllerTests()
        {
            _mockService = new Mock<IAssetService>();
            _controller = new AssignmentsController(_mockService.Object);
        }

        [Fact]
        public async Task ReturnAsset_ReturnsOk()
        {
            var result = await _controller.ReturnAsset(1);
            Assert.IsType<OkResult>(result);
        }
    }
}
