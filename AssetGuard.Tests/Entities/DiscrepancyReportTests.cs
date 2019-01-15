using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class DiscrepancyReportTests
    {
        [Fact]
        public void Entity_DefaultResolution_IsPending()
        {
            var disc = new DiscrepancyReport();
            Assert.Equal(DiscrepancyResolution.Pending, disc.Resolution);
        }

        [Fact]
        public void Entity_SetsType()
        {
            var disc = new DiscrepancyReport { Type = DiscrepancyType.Missing };
            Assert.Equal(DiscrepancyType.Missing, disc.Type);
        }
    }
}
