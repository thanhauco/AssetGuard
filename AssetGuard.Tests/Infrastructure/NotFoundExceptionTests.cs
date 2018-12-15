using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class NotFoundExceptionTests 
    { 
        [Fact] 
        public void Exception_StoresMessage() 
        { 
            var ex = new NotFoundException("Not Found");
            Assert.Equal("Not Found", ex.Message);
        } 
    } 
}
