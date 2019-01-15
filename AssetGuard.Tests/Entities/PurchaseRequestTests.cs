using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class PurchaseRequestTests
    {
        [Fact]
        public void Entity_CalculatesTotalCost()
        {
            var pr = new PurchaseRequest { Quantity = 5, EstimatedUnitCost = 100 };
            Assert.Equal(500, pr.EstimatedTotalCost);
        }

        [Fact]
        public void Entity_DefaultStatus_IsDraft()
        {
            var pr = new PurchaseRequest();
            Assert.Equal(PurchaseRequestStatus.Draft, pr.Status);
        }
    }
}
