using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class UserRoleTests 
    { 
        [Fact] 
        public void Entity_SetsIds() 
        { 
            var ur = new UserRole { UserId = 1, RoleId = 2 };
            Assert.Equal(1, ur.UserId);
        } 
    } 
}
