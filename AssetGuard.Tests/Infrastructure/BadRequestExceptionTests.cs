using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class BadRequestExceptionTests 
    { 
        [Fact] 
        public void Exception_StoresMessage() 
        { 
            var ex = new BadRequestException("Bad");
            Assert.Equal("Bad", ex.Message);
        } 
    } 
}
