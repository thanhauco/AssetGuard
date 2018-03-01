using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers
{
    public class VendorsControllerTests
    {
        private readonly Mock<IVendorService> _mockService;
        private readonly VendorsController _controller;

        public VendorsControllerTests()
        {
            _mockService = new Mock<IVendorService>();
            _controller = new VendorsController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOk()
        {
            var result = await _controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
