using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;

namespace AssetGuard.Tests.Services.Issues 
{ 
    public class IssueServiceResolveTests 
    { 
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly IssueService _service;

        public IssueServiceResolveTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new IssueService(_mockUow.Object);
        }

        [Fact] 
        public async Task ResolveIssue_UpdatesStatus() 
        { 
            var repo = new Mock<IRepository<Issue>>();
            var issue = new Issue { Id = 1, Status = IssueStatus.Open };
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(issue);
            _mockUow.Setup(u => u.Repository<Issue>()).Returns(repo.Object);
            
            await _service.ResolveIssueAsync(1, "Fixed");
            
            Assert.Equal(IssueStatus.Resolved, issue.Status);
            _mockUow.Verify(u => u.CompleteAsync(), Times.Once);
        } 
    } 
}
