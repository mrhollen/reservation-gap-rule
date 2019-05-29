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

            service.CreateCampsite(new Campsite(){ Id = 1, Name = "Cozy Cabin"});
            service.CreateCampsite(new Campsite(){ Id = 2, Name = "Tent"});
            service.CreateCampsite(new Campsite(){ Id = 3, Name = "Shoe"});
            service.CreateCampsite(new Campsite(){ Id = 4, Name = "Hovel"});

            service.CreateReservation(new Reservation(){ StartDate = new DateTime(4.Days().Ticks), EndDate = new DateTime(5.Days().Ticks), CampsiteId = 1});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(12.Days().Ticks), EndDate = new DateTime(15.Days().Ticks), CampsiteId = 2});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(4.Days().Ticks), EndDate = new DateTime(5.Days().Ticks), CampsiteId = 3});
            service.CreateReservation(new Reservation(){ StartDate = new DateTime(4.Days().Ticks), EndDate = new DateTime(5.Days().Ticks), CampsiteId = 4});
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
                StartDate = new DateTime(startDate.Days().Ticks),
                EndDate = new DateTime(endDate.Days().Ticks),
            };

            // Test
            var success = service.CreateReservation(reservation);

            // Assert
            Assert.Equal(success, canCreate);
        }

        [Theory]
        [InlineData(1, "Tent", false)]
        [InlineData(5, "Ritz Carlton", true)]
        public void CanCreateOnlyUniqueCampsites(int id, string name, bool canCreate)
        {
            // Setup
            var campsite = new Campsite()
            {
                Id = id,
                Name = name,
            };

            // Test
            var success = service.CreateCampsite(campsite);

            // Assert
            Assert.Equal(success, canCreate);
        }

        [Theory]
        [InlineData(12, 15, 1)]
        [InlineData(12, 15, 4)]
        [InlineData(3, 5, 2)]
        [InlineData(1, 2, 2)]
        public void CanGetAvailableCampsites(int startDate, int endDate, int idToReturn)
        {
            // Setup
            var targetSpan = new DateTimeSpan(new DateTime(startDate.Days().Ticks), new DateTime(endDate.Days().Ticks));

            // Test
            var campsiteIds = service.GetAvailableCampsites(targetSpan, 1).Select(c => c.Id);

            // Assert
            Assert.Contains(idToReturn, campsiteIds);
        }

        [Theory]
        [InlineData(1, 14, 1)]
        [InlineData(7, 10, 1)]
        [InlineData(0, 2, 10)]
        public void ReturnsEmptySetWhenNoCampsitesAvailable(int startDate, int endDate, int gap)
        {
            // Setup
            var targetSpan = new DateTimeSpan(new DateTime(startDate.Days().Ticks), new DateTime(endDate.Days().Ticks));

            // Test
            var campsiteIds = service.GetAvailableCampsites(targetSpan, gap).Select(c => c.Id);

            // Assert
            Assert.Empty(campsiteIds);
        }
    }
}