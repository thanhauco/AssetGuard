using Xunit;
using AssetGuard.Core.Exceptions;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class ConcurrencyExceptionTests 
    { 
        [Fact] 
        public void Exception_StoresMessage() 
        { 
            var ex = new ConcurrencyException("Conflict");
            Assert.Equal("Conflict", ex.Message);
        } 
    } 
}
