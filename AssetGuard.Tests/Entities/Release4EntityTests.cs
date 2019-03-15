using Xunit;
using AssetGuard.Core.Entities;
using System;

namespace AssetGuard.Tests.Entities
{
    public class Release4EntityTests
    {
        [Fact]
        public void UtilizationMetric_CalculatesRate()
        {
            var metric = new UtilizationMetric { PeriodDays = 30, DaysInUse = 15 };
            Assert.Equal(50, metric.UtilizationRate);
        }

        [Fact]
        public void CostProjection_CalculatesTotal()
        {
            var proj = new CostProjection 
            { 
                ProjectedMaintenanceCost = 1000, 
                ProjectedReplacementCost = 5000, 
                ProjectedInsuranceCost = 500 
            };
            Assert.Equal(6500, proj.TotalProjectedCost);
        }

        [Fact]
        public void CheckoutSession_DefaultStatus_IsActive()
        {
            var session = new CheckoutSession();
            Assert.Equal(CheckoutStatus.Active, session.Status);
        }

        [Fact]
        public void BulkOperation_DefaultStatus_IsPending()
        {
            var op = new BulkOperation();
            Assert.Equal(BulkOperationStatus.Pending, op.Status);
        }

        [Fact]
        public void CustomField_DefaultIsRequired_False()
        {
            var field = new CustomField();
            Assert.False(field.IsRequired);
        }

        [Fact]
        public void SyncJob_DefaultStatus_IsPending()
        {
            var job = new SyncJob();
            Assert.Equal(SyncJobStatus.Pending, job.Status);
        }
    }
}
