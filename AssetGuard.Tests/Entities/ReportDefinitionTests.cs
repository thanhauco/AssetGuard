using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class ReportDefinitionTests 
    { 
        [Fact] 
        public void Entity_SetsType() 
        { 
            var def = new ReportDefinition { Name = "Summary", ReportType = ReportType.Tabular };
            Assert.Equal(ReportType.Tabular, def.ReportType);
        } 
    } 
}
