using System;
using Xunit;
using CodingChallenge;
using CodingChallenge.Extensions;

namespace CodingChallenge.Tests
{
    public class DateTimeSpanTests
    {
        [Theory]
        [InlineData(0, 3, 1, 3, true)]
        [InlineData(0, 3, 4, 6, false)]
        public void CanFindOverlap(int startA, int endA, int startB, int endB, bool shouldOverlap)
        {
            // Setup
            var a = new DateTimeSpan(new DateTime(startA), new DateTime(endA));
            var b = new DateTimeSpan(new DateTime(startB), new DateTime(endB));

            // Test
            var overlap = a.Overlaps(b);

            // Assert
            Assert.Equal(overlap, shouldOverlap);
        }

        [Fact]
        public void ThrowsExceptionWhenSpanGoesBackwards()
        {
            // Setup
            var start = new DateTime(4);
            var end = new DateTime(1);
            Exception exception = null;

            // Test
            try
            {
                var span = new DateTimeSpan(start, end);
            }
            catch(Exception ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsType( typeof(ArgumentOutOfRangeException), exception);
        }
    }
}