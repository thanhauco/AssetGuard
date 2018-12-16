using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ApplicationRoleTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var r = new ApplicationRole { Name = "Admin" };
            Assert.Equal("Admin", r.Name);
        } 
    } 
}
