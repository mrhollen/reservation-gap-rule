using System;

namespace CodingChallenge.Extensions 
{
    public static class DateTimeExtensions
    {
        public static bool WillCreateGap(this DateTime date, DateTime target, int numberOfDaysGap = 1)
        {
            // If we are comparing the 1st and the 2nd then there's one day between
            // So we need to offset by a day
            var maxGapDisallowed = numberOfDaysGap.Days().Add(1.Days());
            var minGapDisallowed = 2.Days();

            var gapCreated = (date - target).Duration(); // Get the absolute value using Duration()

            return gapCreated >= minGapDisallowed && gapCreated <= maxGapDisallowed;
        }
    }
}