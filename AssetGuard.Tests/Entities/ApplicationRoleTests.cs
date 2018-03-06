using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ApplicationRoleTests
    {
        [Fact]
        public void ApplicationRole_Properties_Work()
        {
            var entity = new ApplicationRole { Name = "Test" };
            Assert.Equal("Test", entity.Name);
        }
    }
}
