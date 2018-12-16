using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class LoginResponseTests 
    { 
        [Fact] 
        public void Dto_SetsToken() 
        { 
            var res = new LoginResponse { Token = "ABC" };
            Assert.Equal("ABC", res.Token);
            Assert.True(res.Expiration > System.DateTime.MinValue);
        } 
    } 
}
