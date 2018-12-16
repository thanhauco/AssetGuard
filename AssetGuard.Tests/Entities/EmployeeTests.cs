using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class EmployeeTests 
    { 
        [Fact] 
        public void Entity_SetsProperties() 
        { 
            var emp = new Employee 
            { 
                FirstName = "John", 
                LastName = "Doe", 
                Department = "IT" 
            };
            
            Assert.Equal("John", emp.FirstName);
            Assert.Equal("Doe", emp.LastName);
            Assert.True(emp.IsActive);
        } 
    } 
}
