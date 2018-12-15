using Xunit;
using AssetGuard.Core.Specifications;
using AssetGuard.Core.Entities;
using System;
using System.Linq.Expressions;

namespace AssetGuard.Tests.Infrastructure 
{ 
    public class BaseSpecificationTests 
    { 
        private class TestSpec : BaseSpecification<Asset>
        {
            public TestSpec(Expression<Func<Asset, bool>> criteria) : base(criteria) { }
        }

        [Fact] 
        public void Constructor_SetsCriteria() 
        { 
            var spec = new TestSpec(x => x.Id == 1);
            Assert.NotNull(spec.Criteria);
        } 
    } 
}
