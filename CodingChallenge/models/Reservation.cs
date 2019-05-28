using System;
using Newtonsoft.Json;

namespace CodingChallenge.Models 
{
    public class Reservation 
    {
        [JsonProperty("campsiteId")]
        public int CampsiteId { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public DateTimeSpan Span 
        { 
            get
            {
                return new DateTimeSpan(this.StartDate, this.EndDate);
            } 
            set
            {
                this.StartDate = value.StartDate;
                this.EndDate = value.EndDate;
            }
        }
    }
}