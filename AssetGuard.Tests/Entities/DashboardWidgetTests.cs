using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class DashboardWidgetTests 
    { 
        [Fact] 
        public void Entity_SetsTitle() 
        { 
            var w = new DashboardWidget { Title = "Stats" };
            Assert.Equal("Stats", w.Title);
        } 
    } 
}
