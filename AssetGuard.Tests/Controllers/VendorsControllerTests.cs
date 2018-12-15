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
    public class VendorsControllerTests 
    { 
        private readonly Mock<IVendorService> _mock;
        private readonly VendorsController _controller;

        public VendorsControllerTests()
        {
            _mock = new Mock<IVendorService>();
            _controller = new VendorsController(_mock.Object);
        }

        [Fact] 
        public async Task GetAll_ReturnsOk() 
        { 
            _mock.Setup(s => s.GetAllVendorsAsync()).ReturnsAsync(new List<VendorDto>());
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        } 
    } 
}
