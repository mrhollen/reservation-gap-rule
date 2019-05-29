using System;
using Xunit;
using CodingChallenge;
using CodingChallenge.Extensions;

namespace CodingChallenge.Tests
{
    public class DateTimeExtensionTests
    {
        [Theory]
        [InlineData(0, 2, 1)]
        [InlineData(2, 0, 1)]
        [InlineData(0, 2, 3)]
        [InlineData(2, 0, 3)]
        [InlineData(0, 4, 3)]
        [InlineData(4, 0, 3)]
        [InlineData(5, 0, 10)]
        [InlineData(0, 5, 10)]
        public void DateTimeWillCreateGap(int daysA, int daysB, int daysOfGap)
        {
            // Setup
            var bookDate = new DateTime().AddDays(daysA);
            var previousDate = new DateTime().AddDays(daysB);

            // Test
            var willCreateGap = previousDate.WillCreateGap(bookDate, daysOfGap);

            // Assert
            Assert.True(willCreateGap);
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 3, 1)]
        [InlineData(3, 0, 1)]
        [InlineData(0, 5, 3)]
        [InlineData(5, 0, 3)]
        public void DateTimeWillNotCreateGap(int daysA, int daysB, int daysOfGap)
        {
            // Setup
            var bookDate = new DateTime().AddDays(daysA);
            var previousDate = new DateTime().AddDays(daysB);

            // Test
            var willCreateGap = previousDate.WillCreateGap(bookDate, daysOfGap);

            // Assert
            Assert.False(willCreateGap);
        }
    }
}