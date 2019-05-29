using System;
using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Extensions;
using Newtonsoft.Json;

namespace CodingChallenge.Models 
{
    public class Campsite 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public SortedList<DateTime, Reservation> Reservations { get; set; }

        public Campsite()
        {
            Reservations = new SortedList<DateTime, Reservation>();
        }

        public bool CanBeReserved(DateTimeSpan requestedDates, int numberOfDaysGap)
        {
            var firstPastReservation = Reservations.Where(kvp => kvp.Key <= requestedDates.EndDate).Select(kvp => kvp.Value).LastOrDefault();
            var firstFutureReservation = Reservations.Where(kvp => kvp.Key >= requestedDates.EndDate).Select(kvp => kvp.Value).FirstOrDefault();

            if(firstPastReservation != null && requestedDates.Overlaps(firstPastReservation.Span))
            {
                // The reservation overlaps with the previous reservation
                return false;
            }
            else if(firstFutureReservation != null && requestedDates.Overlaps(firstFutureReservation.Span))
            {
                // The reservation overlaps with the next reservation
                return false;
            }
            else if(firstPastReservation != null && firstPastReservation.EndDate.WillCreateGap(requestedDates.StartDate, numberOfDaysGap))
            {
                // The reservation would create a gap 
                return false;
            }
            else if(firstFutureReservation != null && firstFutureReservation.StartDate.WillCreateGap(requestedDates.EndDate, numberOfDaysGap))
            {
                // The reservation would create a gap
                return false;
            }

            return true;
        }
    }
}