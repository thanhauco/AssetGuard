using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class AssignmentTests 
    { 
        [Fact] 
        public void Entity_SetsAssetId() 
        { 
            var a = new Assignment { AssetId = 1, EmployeeId = 2 };
            Assert.Equal(1, a.AssetId);
        } 
    } 
}
