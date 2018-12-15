using System.Threading.Tasks;
using Xunit;
using AssetGuard.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Moq;
using System.IO;
using System;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class ErrorHandlingMiddlewareTests 
    { 
        [Fact] 
        public async Task Invoke_CallsNextDelegate() 
        { 
            var nextMock = new Mock<RequestDelegate>();
            var middleware = new ErrorHandlingMiddleware(nextMock.Object);
            var context = new DefaultHttpContext();

            await middleware.Invoke(context);

            nextMock.Verify(n => n(context), Times.Once);
        }
    } 
}
