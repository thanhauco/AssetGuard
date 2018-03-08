using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class WorkflowTests
    {
        [Fact]
        public void Workflow_Properties_Work()
        {
            var entity = new Workflow { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
