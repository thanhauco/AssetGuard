using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_Properties_Work()
        {
            var entity = new Employee { FirstName = "Test" };
            Assert.Equal("Test", entity.FirstName);
        }
    }
}
