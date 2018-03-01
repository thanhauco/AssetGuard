using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Controllers
{
    public class MaintenanceControllerTests
    {
        private readonly Mock<IMaintenanceService> _mockService;
        private readonly MaintenanceController _controller;

        public MaintenanceControllerTests()
        {
            _mockService = new Mock<IMaintenanceService>();
            _controller = new MaintenanceController(_mockService.Object);
        }

        [Fact]
        public async Task GetHistory_ReturnsOk()
        {
            _mockService.Setup(s => s.GetMaintenanceHistoryAsync(1)).ReturnsAsync(new List<MaintenanceRecordDto>());
            var result = await _controller.GetHistory(1);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
