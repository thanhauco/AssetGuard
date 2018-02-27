using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers
{
    public class LocationsControllerTests
    {
        private readonly Mock<ILocationService> _mockService;
        private readonly LocationsController _controller;

        public LocationsControllerTests()
        {
            _mockService = new Mock<ILocationService>();
            _controller = new LocationsController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var result = await _controller.Get();
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
