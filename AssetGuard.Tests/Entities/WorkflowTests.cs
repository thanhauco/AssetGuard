using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class WorkflowTests 
    { 
        [Fact] 
        public void Entity_SetsActive_Default() 
        { 
            var wf = new Workflow { Name = "Purchase" };
            Assert.True(wf.IsActive);
            Assert.Equal("Purchase", wf.Name);
        } 
    } 
}
