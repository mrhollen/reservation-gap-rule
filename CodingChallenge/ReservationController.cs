using CodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private ReservationService reservationService;

        public ReservationController(ReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet("check")]
        public IActionResult CheckReservations()
        {
            return Ok();
        }
    }
}