using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Interfaces;
using AssetGuard.Core.Entities;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.Services.IssueTracking
{
    public class IssueServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly IssueService _service;

        public IssueServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new IssueService(_mockUow.Object);
        }

        [Fact]
        public async Task ReportIssue_AddsToRepository()
        {
            var repoMock = new Mock<IRepository<Issue>>();
            var assetRepoMock = new Mock<IRepository<Asset>>();
            
            _mockUow.Setup(u => u.Repository<Issue>()).Returns(repoMock.Object);
            _mockUow.Setup(u => u.Repository<Asset>()).Returns(assetRepoMock.Object);

            var dto = new CreateIssueDto { Title = "Test Issue", AssetId = 1 };
            await _service.ReportIssueAsync(dto);

            repoMock.Verify(r => r.AddAsync(It.IsAny<Issue>()), Times.Once);
        }
    }
}
