using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class DocumentCategoryTests 
    { 
        [Fact] 
        public void Entity_SetsName() 
        { 
            var c = new DocumentCategory { Name = "C1" };
            Assert.Equal("C1", c.Name);
        } 
    } 
}
