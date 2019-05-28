using System;
using Xunit;
using CodingChallenge;
using CodingChallenge.Extensions;
using CodingChallenge.Models;
using System.Linq;

namespace CodingChallenge.Tests
{
    public class ReservationServiceTests
    {
        private ReservationService service;

        public ReservationServiceTests()
        {
            service = new ReservationService();

            service.CreateReservation(new Reservation(){ StartDate = new DateTime(1), EndDate = new DateTime(5), CampsiteId = 1});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(9), EndDate = new DateTime(10), CampsiteId = 1});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(12), EndDate = new DateTime(15), CampsiteId = 2});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(3), EndDate = new DateTime(5), CampsiteId = 3});
        }

        [Theory]
        [InlineData(3, 5, 1, false)]
        [InlineData(6, 7, 1, true)]
        [InlineData(12, 15, 1, true)]
        public void CanCreateOnlyUniqueReservations(int startDate, int endDate, int campsiteId, bool canCreate)
        {
            // Setup
            var reservation = new Reservation()
            {
                CampsiteId = campsiteId,
                StartDate = new DateTime(startDate),
                EndDate = new DateTime(endDate),
            };

            // Test
            var success = service.CreateReservation(reservation);

            // Assert
            Assert.Equal(success, canCreate);
        }

        [Theory]
        [InlineData(12, 15, 1)]
        [InlineData(3, 5, 2)]
        public void CanGetAvailableCampsites(int startDate, int endDate, int idToReturn)
        {
            // Setup
            var targetSpan = new DateTimeSpan(new DateTime(startDate), new DateTime(endDate));

            // Test
            var campsiteIds = service.GetAvailableCampsites(targetSpan).Select(c => c.Id);

            // Assert
            Assert.Contains(idToReturn, campsiteIds);
        }

        [Fact]
        public void ReturnsEmptySetWhenNoCampsitesAvailable()
        {
            // Setup
            var targetSpan = new DateTimeSpan(new DateTime(1), new DateTime(14));

            // Test
            var campsiteIds = service.GetAvailableCampsites(targetSpan).Select(c => c.Id);

            // Assert
            Assert.Empty(campsiteIds);
        }
    }
}