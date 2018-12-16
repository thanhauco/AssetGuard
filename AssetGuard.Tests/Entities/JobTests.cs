using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class JobTests 
    { 
        [Fact] 
        public void Entity_SetsNotes() 
        { 
            var j = new Job { TechnicianNotes = "Done" };
            Assert.Equal("Done", j.TechnicianNotes);
        } 
    } 
}
