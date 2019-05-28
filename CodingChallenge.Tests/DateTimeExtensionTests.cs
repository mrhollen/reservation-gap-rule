using System;
using Xunit;
using CodingChallenge;
using CodingChallenge.Extensions;

namespace CodingChallenge.Tests
{
    public class DateTimeExtensionTests
    {
        [Fact]
        public void FutureDateTimeWillNotCreateGap()
        {
            // Setup
            var bookDate = new DateTime().AddDays(2);
            var previousDate = new DateTime();
            var gap = 1.Days();

            // Test
            var createdGap = previousDate.WillCreateGap(bookDate, gap);

            // Assert
            Assert.True(createdGap);
        }

        [Fact]
        public void PastDateTimeWillNotCreateGap()
        {
            // Setup
            var bookDate = new DateTime();
            var previousDate = new DateTime().AddDays(2);
            var gap = 1.Days();

            // Test
            var createdGap = previousDate.WillCreateGap(bookDate, gap);

            // Assert
            Assert.True(createdGap);
        }

        [Fact]
        public void FutureDateTimeWillCreateGap()
        {
            // Setup
            var bookDate = new DateTime().AddHours(5);
            var previousDate = new DateTime();
            var gap = 1.Days();

            // Test
            var createdGap = previousDate.WillCreateGap(bookDate, gap);

            // Assert
            Assert.False(createdGap);
        }

        [Fact]
        public void PastDateTimeWillCreateGap()
        {
            // Setup
            var bookDate = new DateTime();
            var previousDate = new DateTime().AddHours(5);
            var gap = 1.Days();

            // Test
            var createdGap = previousDate.WillCreateGap(bookDate, gap);

            // Assert
            Assert.False(createdGap);
        }
    }
}