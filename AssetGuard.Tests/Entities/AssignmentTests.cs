using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class AssignmentTests
    {
        [Fact]
        public void Assignment_Properties_Work()
        {
            var entity = new Assignment { AssetId = 1 };
            Assert.Equal(1, entity.AssetId);
        }
    }
}
