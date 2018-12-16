using Xunit;
using AssetGuard.Services.DTOs;

namespace AssetGuard.Tests.DTOs 
{ 
    public class LoginRequestTests 
    { 
        [Fact] 
        public void Dto_SetsProperties() 
        { 
            var req = new LoginRequest { Username = "user", Password = "password" };
            Assert.Equal("user", req.Username);
            Assert.Equal("password", req.Password);
        } 
    } 
}
