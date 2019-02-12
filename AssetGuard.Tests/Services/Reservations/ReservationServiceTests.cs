using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using AssetGuard.Services.Services;
using AssetGuard.Core.Entities;
using AssetGuard.Core.Interfaces;
using AssetGuard.Services.DTOs;
using System.Collections.Generic;

namespace AssetGuard.Tests.Services.Reservations
{
    public class ReservationServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly ReservationService _service;

        public ReservationServiceTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _service = new ReservationService(_mockUow.Object);
        }

        [Fact]
        public async Task CreateReservation_AddsEntity()
        {
            var repo = new Mock<IRepository<AssetReservation>>();
            repo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<AssetReservation>());
            _mockUow.Setup(u => u.Repository<AssetReservation>()).Returns(repo.Object);

            await _service.CreateReservationAsync(new CreateReservationDto
            {
                AssetId = 1,
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(5)
            });

            repo.Verify(r => r.AddAsync(It.IsAny<AssetReservation>()), Times.Once);
        }

        [Fact]
        public async Task ApproveReservation_SetsApprovedStatus()
        {
            var reservation = new AssetReservation { Id = 1, Status = ReservationStatus.Pending };
            var repo = new Mock<IRepository<AssetReservation>>();
            repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(reservation);
            _mockUow.Setup(u => u.Repository<AssetReservation>()).Returns(repo.Object);

            await _service.ApproveReservationAsync(1, 10);

            Assert.Equal(ReservationStatus.Approved, reservation.Status);
        }
    }
}
