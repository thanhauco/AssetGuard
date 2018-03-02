using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers.AdvancedAssets
{
    public class LicensesControllerTests
    {
        private readonly Mock<ILicenseService> _mock;
        private readonly LicensesController _controller;

        public LicensesControllerTests()
        {
            _mock = new Mock<ILicenseService>();
            _controller = new LicensesController(_mock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var res = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(res);
        }
    }
}
