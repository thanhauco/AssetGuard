using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers.Reporting
{
    public class ReportsControllerTests
    {
        private readonly Mock<IReportingService> _mock;
        private readonly ReportsController _controller;

        public ReportsControllerTests()
        {
            _mock = new Mock<IReportingService>();
            _controller = new ReportsController(_mock.Object);
        }

        [Fact]
        public async Task GetDashboard_ReturnsOk()
        {
            var res = await _controller.GetDashboard();
            Assert.IsType<OkObjectResult>(res.Result);
        }
    }
}
