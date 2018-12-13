using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day11Tests
    {
        [Theory]
        [InlineData("18", 33, 45)]
        [InlineData("42", 21, 61)]
        public void Part01(string input, int expectedX, int expectedY) 
        {
            // Act
            var actual = Day11.Part01(input);

            // Assert
            Assert.Equal((expectedX, expectedY), actual);
        }

        [Fact]
        public void Part01_Answer() 
        {
            // Arrange
            var input = Day11.ReadInput();

            // Act
            var actual = Day11.Part01(input);

            // Assert
            Assert.Equal((233, 36), actual);
        }


        [Theory]
        [InlineData("18", 90, 269, 16)]
        [InlineData("42", 232, 251, 12)]
        public void Part02(string input, int expectedX, int expectedY, int expectedSquareSize) 
        {
            // Act
            var actual = Day11.Part02(input);

            // Assert
            Assert.Equal((expectedX, expectedY, expectedSquareSize), actual);
        }

        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day11.ReadInput();

            // Act
            var actual = Day11.Part02(input);

            // Assert
            Assert.Equal((231, 107, 14), actual);
        }
    }
}
