using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ApprovalLogTests 
    { 
        [Fact] 
        public void Entity_SetsAction() 
        { 
            var l = new ApprovalLog { Action = "Approved" };
            Assert.Equal("Approved", l.Action);
        } 
    } 
}
