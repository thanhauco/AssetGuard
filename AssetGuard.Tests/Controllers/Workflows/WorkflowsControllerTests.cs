using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Api.Controllers;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Controllers.Workflows
{
    public class WorkflowsControllerTests
    {
        private readonly Mock<IWorkflowService> _mock;
        private readonly WorkflowsController _controller;

        public WorkflowsControllerTests()
        {
            _mock = new Mock<IWorkflowService>();
            _controller = new WorkflowsController(_mock.Object);
        }

        [Fact]
        public async Task Submit_ReturnsOk()
        {
            var res = await _controller.Submit(new SubmitApprovalDto());
            Assert.IsType<OkObjectResult>(res);
        }
    }
}
