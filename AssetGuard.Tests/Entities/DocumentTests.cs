using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class DocumentTests 
    { 
        [Fact] 
        public void Entity_Initialization() 
        { 
            var doc = new Document { Title = "Manual" };
            Assert.NotNull(doc.Versions);
            Assert.Equal("Manual", doc.Title);
        } 
    } 
}
