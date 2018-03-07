using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class DocumentVersionTests
    {
        [Fact]
        public void DocumentVersion_Properties_Work()
        {
            var entity = new DocumentVersion { FileName = "Test" };
            Assert.Equal("Test", entity.FileName);
        }
    }
}
