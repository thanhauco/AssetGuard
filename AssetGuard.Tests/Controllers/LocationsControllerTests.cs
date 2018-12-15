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
    public class LocationsControllerTests 
    { 
        private readonly Mock<ILocationService> _mock;
        private readonly LocationsController _controller;

        public LocationsControllerTests()
        {
            _mock = new Mock<ILocationService>();
            _controller = new LocationsController(_mock.Object);
        }

        [Fact] 
        public async Task GetSites_ReturnsOk() 
        { 
            _mock.Setup(s => s.GetAllSitesAsync()).ReturnsAsync(new List<SiteDto>());
            var result = await _controller.GetSites();
            Assert.IsType<OkObjectResult>(result);
        } 
    } 
}
