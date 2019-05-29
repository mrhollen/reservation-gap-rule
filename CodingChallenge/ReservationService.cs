using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Models;
using CodingChallenge.Extensions;

namespace CodingChallenge 
{
    public class ReservationService
    {
        private HashSet<Campsite> campsites = new HashSet<Campsite>(new CampsiteEqualityComparer());

        public bool CreateCampsite(Campsite campsite)
        {
            return campsites.Add(campsite);
        }

        public bool CreateReservation(Reservation reservation)
        {
            Campsite campsite;
            if(campsites.TryGetValue(new Campsite(){Id = reservation.CampsiteId}, out campsite))
            {
                if(campsite.CanBeReserved(reservation.Span, 1))
                {
                    return campsite.Reservations.TryAdd(reservation.EndDate, reservation);
                }

                return false;
            }
            
            return false;
        }

        public IEnumerable<Campsite> GetAvailableCampsites(DateTimeSpan requestedDates, int numberOfDaysGap)
        {
            return campsites.Where(c => c.CanBeReserved(requestedDates, numberOfDaysGap));
        }
    }
}