using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class ContractTests
    {
        [Fact]
        public void Contract_Properties_Work()
        {
            var entity = new Contract { Title = "Test" };
            Assert.Equal("Test", entity.Title);
        }
    }
}
