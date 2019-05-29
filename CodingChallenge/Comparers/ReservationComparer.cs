using System;
using System.Collections.Generic;
using CodingChallenge.Models;

namespace CodingChallenge
{
    public class ReservationComparer : IComparer<Reservation>
    {
        public int Compare(Reservation a, Reservation b)
        {
            if(a.CampsiteId == b.CampsiteId && a.Span.Overlaps(b.Span))
            {
                throw new InvalidOperationException("Cannot compare overlapping reservations");
            }

            var result = a.StartDate.CompareTo(b.EndDate);

            if(result == 0)
            {
                return a.CampsiteId.CompareTo(b.EndDate);
            } 
            else 
            {
                return result;
            }
        }
    }
}