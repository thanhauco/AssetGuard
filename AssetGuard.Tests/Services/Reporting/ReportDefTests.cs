using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Services.Reporting 
{ 
    public class ReportDefTests 
    { 
        [Fact] 
        public void Entity_SetsQuery() 
        { 
            var def = new ReportDefinition { QueryJson = "{}" };
            Assert.Equal("{}", def.QueryJson);
        } 
    } 
}
