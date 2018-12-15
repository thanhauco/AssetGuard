using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.Issues 
{ 
    public class IssueServiceReportTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly IssueService _service;

        public IssueServiceReportTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new IssueService(_mockUow.Object);
        }

        [Fact] 
        public async Task ReportIssue_AddsEntity() 
        { 
            var repo = new Mock<IRepository<Issue>>();
            _mockUow.Setup(u => u.Repository<Issue>()).Returns(repo.Object);
            
            await _service.ReportIssueAsync(new CreateIssueDto { Title = "Bug" });
            
            repo.Verify(r => r.AddAsync(It.IsAny<Issue>()), Times.Once);
        } 
    } 
}
