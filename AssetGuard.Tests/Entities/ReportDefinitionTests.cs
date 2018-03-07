using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ReportDefinitionTests
    {
        [Fact]
        public void ReportDefinition_Properties_Work()
        {
            var entity = new ReportDefinition { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
