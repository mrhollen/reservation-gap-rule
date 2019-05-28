using System;
using Xunit;
using CodingChallenge;
using CodingChallenge.Extensions;

namespace CodingChallenge.Tests
{
    public class IntegerExtensionTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void CanCreateSeconds(int input)
        {
            // Setup
            var seconds = input.Seconds();
            var testSpan = new TimeSpan(0, 0, 0, input);

            // Test
            var testResult = seconds == testSpan;

            // Assert
            Assert.True(testResult);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void CanCreateMinutes(int input)
        {
            // Setup
            var minutes = input.Minutes();
            var testSpan = new TimeSpan(0, 0, input, 0);

            // Test
            var testResult = minutes == testSpan;

            // Assert
            Assert.True(testResult);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void CanCreateHours(int input)
        {
            // Setup
            var hours = input.Hours();
            var testSpan = new TimeSpan(0, input, 0, 0);

            // Test
            var testResult = hours == testSpan;

            // Assert
            Assert.True(testResult);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(-2)]
        public void CanCreateDays(int input)
        {
            // Setup
            var days = input.Days();
            var testSpan = new TimeSpan(input, 0, 0, 0);

            // Test
            var testResult = days == testSpan;

            // Assert
            Assert.True(testResult);
        }
    }
}