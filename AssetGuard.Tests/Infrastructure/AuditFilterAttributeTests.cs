using Xunit;
using AssetGuard.Api.Filters;
using AssetGuard.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class AuditFilterAttributeTests 
    { 
        [Fact] 
        public async Task OnActionExecution_LogsAudit() 
        { 
            var mockAudit = new Mock<IAuditService>();
            var filter = new AuditFilterAttribute(mockAudit.Object);
            
            var context = new ActionExecutingContext(
                new ActionContext(new DefaultHttpContext(), new RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()),
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                new Mock<Controller>().Object
            );
            
            var executedContext = new ActionExecutedContext(context, new List<IFilterMetadata>(), new Mock<Controller>().Object);

            filter.OnActionExecuted(executedContext);

            // Since it's async void or task in reality, checking invocation
            mockAudit.Verify(a => a.LogAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        } 
    } 
}
