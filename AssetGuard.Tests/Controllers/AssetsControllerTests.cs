using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using AssetGuard.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AssetGuard.Tests.Controllers 
{ 
    public class AssetsControllerTests 
    { 
        private readonly Mock<IAssetService> _mock;
        private readonly AssetsController _controller;

        public AssetsControllerTests()
        {
            _mock = new Mock<IAssetService>();
            _controller = new AssetsController(_mock.Object);
        }

        [Fact] 
        public async Task GetAll_ReturnsList() 
        { 
            _mock.Setup(s => s.GetAllAssetsAsync()).ReturnsAsync(new List<AssetDto>());
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOk()
        {
            _mock.Setup(s => s.GetAssetByIdAsync(1)).ReturnsAsync(new AssetDto());
            var result = await _controller.GetById(1);
            Assert.IsType<OkObjectResult>(result);
        }
    } 
}
