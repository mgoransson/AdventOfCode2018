using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };

            // Act
            var actual = Day06.Part01(input);

            // Assert
            Assert.Equal(17, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day06.ReadInput();

            // Act
            var actual = Day06.Part01(input);

            // Assert
            Assert.Equal(3687, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new [] {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };
            var maxSum = 32;

            // Act
            var actual = Day06.Part02(input, maxSum);

            // Assert
            Assert.Equal(16, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day06.ReadInput();
            var maxSum = 10000;

            // Act
            var actual = Day06.Part02(input, maxSum);

            // Assert
            Assert.Equal(40134, actual);
        }
    }
}
