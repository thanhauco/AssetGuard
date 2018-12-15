using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Services.Reporting 
{ 
    public class ReportScheduleTests 
    { 
        [Fact] 
        public void Entity_SetsCron() 
        { 
            var sch = new ReportSchedule { CronExpression = "* * * * *" };
            Assert.Equal("* * * * *", sch.CronExpression);
            Assert.True(sch.IsEnabled);
        } 
    } 
}
