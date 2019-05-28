using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodingChallenge.Models
{
    public class AvailabilityRequest
    {
        [JsonProperty("search")]
        public Search Search { get; set; }

        [JsonProperty("campsites")]
        public List<Campsite> Campsites { get; set; }

        [JsonProperty("reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}