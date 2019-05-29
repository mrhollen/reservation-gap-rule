using System;

namespace CodingChallenge.Extensions 
{
    public static class DateTimeExtensions
    {
        public static bool WillCreateGap(this DateTime date, DateTime target, int numberOfDaysGap)
        {
            // If we are comparing the 1st and the 2nd then there's one day between
            // So we need to offset by a day
            return (date - target).Duration() == numberOfDaysGap.Days().Add(1.Days());
        }
    }
}