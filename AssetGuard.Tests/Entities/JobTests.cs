using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities
{
    public class JobTests
    {
        [Fact]
        public void Job_Properties_Work()
        {
            var entity = new Job { TechnicianNotes = "Test" };
            Assert.Equal("Test", entity.TechnicianNotes);
        }
    }
}
