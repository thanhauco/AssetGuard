using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace AssetGuard.Tests.Services.Workflows
{
    public class WorkflowServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly WorkflowService _service;

        public WorkflowServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new WorkflowService(_mockUow.Object);
        }

        [Fact]
        public async Task SubmitRequest_CreatesRequest()
        {
            var wfRepo = new Mock<IRepository<Workflow>>();
            wfRepo.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Workflow, bool>>>()))
                .ReturnsAsync(new List<Workflow> { new Workflow { Id = 1, Name = "Test" } });
            
            var reqRepo = new Mock<IRepository<ApprovalRequest>>();
            
            _mockUow.Setup(u => u.Repository<Workflow>()).Returns(wfRepo.Object);
            _mockUow.Setup(u => u.Repository<ApprovalRequest>()).Returns(reqRepo.Object);

            await _service.SubmitRequestAsync(new SubmitApprovalDto { WorkflowName = "Test" }, 1);
            
            reqRepo.Verify(r => r.AddAsync(It.IsAny<ApprovalRequest>()), Times.Once);
        }
    }
}
