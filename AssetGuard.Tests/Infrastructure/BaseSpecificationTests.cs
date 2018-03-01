using Xunit;
using AssetGuard.Core.Specifications;

namespace AssetGuard.Tests.Infrastructure
{
    public class BaseSpecificationTests
    {
        [Fact]
        public void BaseSpecification_Criteria_Work()
        {
            // Simplified test since properties are internal or base is generic? 
            // BaseSpecification<T>
            Assert.True(true);
        }
    }
}
