using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetGuard.Tests.Controllers.Documents
{
    public class DocumentsControllerTests
    {
        private readonly Mock<IDocumentService> _mock;
        private readonly DocumentsController _controller;

        public DocumentsControllerTests()
        {
            _mock = new Mock<IDocumentService>();
            _controller = new DocumentsController(_mock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var res = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(res);
        }
    }
}
