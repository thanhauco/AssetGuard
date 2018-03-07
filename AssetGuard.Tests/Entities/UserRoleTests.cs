using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class UserRoleTests
    {
        [Fact]
        public void UserRole_Properties_Work()
        {
            var entity = new UserRole { UserId = 1 };
            Assert.Equal(1, entity.UserId);
        }
    }
}
