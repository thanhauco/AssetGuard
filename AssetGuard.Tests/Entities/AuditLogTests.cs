using Xunit;
using AssetGuard.Core.Entities;
using System;

namespace AssetGuard.Tests.Entities 
{ 
    public class AuditLogTests 
    { 
        [Fact] 
        public void Entity_SetsTimestamp() 
        { 
            var log = new AuditLog { Action = "Login" };
            Assert.True(log.Timestamp <= DateTime.UtcNow);
            Assert.Equal("Login", log.Action);
        } 
    } 
}
