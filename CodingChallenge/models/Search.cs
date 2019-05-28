using System;
using Newtonsoft.Json;

namespace CodingChallenge.Models 
{
    public class Search
    {
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
    }
}