using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ApprovalRequestTests 
    { 
        [Fact] 
        public void Entity_SetsStatus() 
        { 
            var r = new ApprovalRequest { Status = "Pending" };
            Assert.Equal("Pending", r.Status);
        } 
    } 
}
