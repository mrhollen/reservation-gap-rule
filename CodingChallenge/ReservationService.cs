using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Models;

namespace CodingChallenge 
{
    public class ReservationService
    {
        private SortedSet<Reservation> reservations = new SortedSet<Reservation>(new ReservationComparer());

        public bool CreateReservation(Reservation reservation)
        {
            var firstFutureDate = reservations.Where(r => r.StartDate >= reservation.StartDate && r.CampsiteId == reservation.CampsiteId).FirstOrDefault();
            var firstPastDate = reservations.Where(r => r.StartDate <= reservation.StartDate && r.CampsiteId == reservation.CampsiteId).FirstOrDefault();

            if(firstFutureDate != null && firstFutureDate.Span.Overlaps(reservation.Span))
            {
                return false;
            }
            else if(firstPastDate != null && firstPastDate.Span.Overlaps(reservation.Span))
            {
                return false;
            }

            return reservations.Add(reservation);
        }

        public IEnumerable<Campsite> GetAvailableCampsites(DateTimeSpan requestedDates)
        {
            throw new NotImplementedException();
        }
    }
}