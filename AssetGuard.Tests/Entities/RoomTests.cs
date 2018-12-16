using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class RoomTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var r = new Room { Name = "R1", BuildingId = 1 };
            Assert.Equal("R1", r.Name);
        } 
    } 
}
