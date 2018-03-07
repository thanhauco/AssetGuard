using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class DocumentCategoryTests
    {
        [Fact]
        public void DocumentCategory_Properties_Work()
        {
            var entity = new DocumentCategory { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
