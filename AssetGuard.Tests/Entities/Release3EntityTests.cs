using Xunit;
using AssetGuard.Core.Entities;
using System;

namespace AssetGuard.Tests.Entities
{
    public class AssetReservationTests
    {
        [Fact]
        public void Entity_DefaultStatus_IsPending()
        {
            var reservation = new AssetReservation();
            Assert.Equal(ReservationStatus.Pending, reservation.Status);
        }

        [Fact]
        public void Entity_SetsCreatedAt()
        {
            var reservation = new AssetReservation();
            Assert.True(reservation.CreatedAt <= DateTime.UtcNow);
        }
    }

    public class WarrantyTests
    {
        [Fact]
        public void IsActive_WhenInRange_ReturnsTrue()
        {
            var warranty = new Warranty
            {
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10)
            };
            Assert.True(warranty.IsActive);
        }

        [Fact]
        public void IsActive_WhenExpired_ReturnsFalse()
        {
            var warranty = new Warranty
            {
                StartDate = DateTime.UtcNow.AddDays(-20),
                EndDate = DateTime.UtcNow.AddDays(-10)
            };
            Assert.False(warranty.IsActive);
        }
    }

    public class AssetTransferTests
    {
        [Fact]
        public void Entity_DefaultIsCompleted_False()
        {
            var transfer = new AssetTransfer();
            Assert.False(transfer.IsCompleted);
        }
    }
}
