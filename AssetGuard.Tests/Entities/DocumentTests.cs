using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class DocumentTests
    {
        [Fact]
        public void Document_Properties_Work()
        {
            var entity = new Document { Title = "Test" };
            Assert.Equal("Test", entity.Title);
        }
    }
}
