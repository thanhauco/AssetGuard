using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class IssueTests
    {
        [Fact]
        public void Issue_Properties_Work()
        {
            var entity = new Issue { Title = "Test" };
            Assert.Equal("Test", entity.Title);
        }
    }
}
