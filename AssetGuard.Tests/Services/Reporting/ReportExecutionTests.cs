using Xunit;
using AssetGuard.Core.Entities;
using System;

namespace AssetGuard.Tests.Services.Reporting 
{ 
    public class ReportExecutionTests 
    { 
        [Fact] 
        public void Entity_SetsExecutionTime() 
        { 
            var ex = new ReportExecution { ExecutedAt = DateTime.Now, IsSuccess = true };
            Assert.True(ex.IsSuccess);
            Assert.True(ex.ExecutedAt > DateTime.MinValue);
        } 
    } 
}
