using System;
using System.Collections.Generic;
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
        public SortedSet<DateTime> ReservationTimes { get; set; }
    }
}