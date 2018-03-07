using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ApplicationUserTests
    {
        [Fact]
        public void ApplicationUser_Properties_Work()
        {
            var entity = new ApplicationUser { UserName = "Test" };
            Assert.Equal("Test", entity.UserName);
        }
    }
}
