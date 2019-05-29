using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpPost("check")]
        public IActionResult CheckReservations([FromBody] AvailabilityRequest availabilityRequest)
        {
            // Add the campsites
            foreach(var campsite in availabilityRequest.Campsites)
            {
                this.reservationService.CreateCampsite(campsite);
            }

            // Add the reservations
            foreach(var reservation in availabilityRequest.Reservations)
            {
                this.reservationService.CreateReservation(reservation);
            }

            // Search for availability
            var searchSpan = new DateTimeSpan(availabilityRequest.Search.StartDate, availabilityRequest.Search.EndDate);

            // Return as Json
            return Json(this.reservationService.GetAvailableCampsites(searchSpan, 1));
        }
    }
}