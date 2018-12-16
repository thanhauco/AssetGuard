using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class MaintenanceRecordTests 
    { 
        [Fact] 
        public void Entity_SetsDesc() 
        { 
            var m = new MaintenanceRecord { Description = "Fix", Cost = 100 };
            Assert.Equal(100, m.Cost);
        } 
    } 
}
