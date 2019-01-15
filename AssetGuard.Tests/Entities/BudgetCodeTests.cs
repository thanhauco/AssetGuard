using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class BudgetCodeTests
    {
        [Fact]
        public void Entity_CalculatesRemainingAmount()
        {
            var bc = new BudgetCode { AllocatedAmount = 10000, SpentAmount = 3000 };
            Assert.Equal(7000, bc.RemainingAmount);
        }

        [Fact]
        public void Entity_DefaultIsActive_True()
        {
            var bc = new BudgetCode();
            Assert.True(bc.IsActive);
        }
    }
}
