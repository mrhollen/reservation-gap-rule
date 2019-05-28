using System;

namespace CodingChallenge.Extensions 
{
    public static class DateTimeExtensions
    {
        public static bool WillCreateGap(this DateTime date, DateTime target, TimeSpan gap)
        {
            return (date - target).Duration() < gap;
        }
    }
}