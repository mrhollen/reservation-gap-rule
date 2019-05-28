using System;

namespace CodingChallenge.Extensions 
{
    public static class IntegerExtensions
    {
        public static TimeSpan Seconds(this int numberOfSeconds)
        {
            return new TimeSpan(0, 0, 0, numberOfSeconds);
        }

        public static TimeSpan Minutes(this int numberOfMinutes)
        {
            return new TimeSpan(0, 0, numberOfMinutes, 0);
        }

        public static TimeSpan Hours(this int numberOfHours)
        {
            return new TimeSpan(0, numberOfHours, 0, 0);
        }

        public static TimeSpan Days(this int numberOfDays)
        {
            return new TimeSpan(numberOfDays, 0, 0, 0);
        }
    }
}