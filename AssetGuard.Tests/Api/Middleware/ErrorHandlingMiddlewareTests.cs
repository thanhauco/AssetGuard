using Xunit;
using AssetGuard.Api.Middleware;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AssetGuard.Tests.Api.Middleware
{
    public class ErrorHandlingMiddlewareTests
    {
        [Fact]
        public async Task Invoke_CallsNext()
        {
            bool called = false;
            RequestDelegate next = (c) => { called = true; return Task.CompletedTask; };
            var middleware = new ErrorHandlingMiddleware(next);
            
            await middleware.Invoke(new DefaultHttpContext());
            
            Assert.True(called);
        }
    }
}
