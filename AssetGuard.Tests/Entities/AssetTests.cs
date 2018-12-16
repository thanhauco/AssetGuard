using Xunit;
using AssetGuard.Core.Entities;
using System;

namespace AssetGuard.Tests.Entities 
{ 
    public class AssetTests 
    { 
        [Fact] 
        public void Entity_SetsProperties_Correctly() 
        { 
            var asset = new Asset 
            { 
                Name = "Laptop",
                SerialNumber = "SN123",
                PurchaseDate = DateTime.Now,
                Cost = 1000m
            };
            
            Assert.Equal("Laptop", asset.Name);
            Assert.Equal("SN123", asset.SerialNumber);
            Assert.Equal(1000m, asset.Cost);
            Assert.Equal(AssetStatus.Available, asset.Status); // Default check
        } 
    } 
}
