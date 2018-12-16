using Xunit;
using AssetGuard.Core.Entities;

namespace AssetGuard.Tests.Entities 
{ 
    public class IssueTests 
    { 
        [Fact] 
        public void Entity_Defaults() 
        { 
            var issue = new Issue { Title = "Screen Broken" };
            Assert.Equal(IssuePriority.Normal, issue.Priority);
            Assert.Equal(IssueStatus.Open, issue.Status);
        } 
    } 
}
