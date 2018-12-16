using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ApplicationUserTests 
    { 
        [Fact] 
        public void Entity_SetsUsername() 
        { 
            var u = new ApplicationUser { UserName = "admin" };
            Assert.Equal("admin", u.UserName);
        } 
    } 
}
