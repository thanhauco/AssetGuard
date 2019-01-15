using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class LabelTemplateTests
    {
        [Fact]
        public void Entity_DefaultSize_IsMedium()
        {
            var template = new LabelTemplate();
            Assert.Equal(LabelSize.Medium, template.Size);
        }

        [Fact]
        public void Entity_DefaultIncludes_AreTrue()
        {
            var template = new LabelTemplate();
            Assert.True(template.IncludeQrCode);
            Assert.True(template.IncludeBarcode);
        }
    }
}
