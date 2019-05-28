using Xunit;

namespace CodingChallenge.Tests
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            // Setup
            var a = 1;
            var b = 2;

            // Test
            var c = a + b;

            // Assert
            Assert.Equal(c, 3);
        }
    }
}