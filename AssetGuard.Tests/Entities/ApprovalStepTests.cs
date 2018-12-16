using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ApprovalStepTests 
    { 
        [Fact] 
        public void Entity_SetsOrder() 
        { 
            var s = new ApprovalStep { SequenceOrder = 1 };
            Assert.Equal(1, s.SequenceOrder);
        } 
    } 
}
