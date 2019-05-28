using System;

namespace CodingChallenge 
{
    public class DateTimeSpan 
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan Duration => EndDate - StartDate;
        
        public DateTimeSpan(){}

        public DateTimeSpan(DateTime startDate, DateTime endDate)
        {
            if(startDate > endDate)
            {
                throw new ArgumentOutOfRangeException("Start date must come before end date");
            }

            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTimeSpan(DateTime startDate, TimeSpan duration)
        {
            this.StartDate = startDate;
            this.EndDate = startDate.Add(duration);
        }

        public bool Overlaps(DateTimeSpan spanToCompare)
        {
            return this.StartDate <= spanToCompare.EndDate && spanToCompare.StartDate <= this.EndDate;
        }
    }
}