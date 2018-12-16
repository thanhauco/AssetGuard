using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class DocumentVersionTests 
    { 
        [Fact] 
        public void Entity_SetsVersion() 
        { 
            var d = new DocumentVersion { VersionNumber = 1 };
            Assert.Equal(1, d.VersionNumber);
        } 
    } 
}
