using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day09Tests
    {
        [Theory]
        [InlineData("10 players; last marble is worth 1618 points", 8317)]
        [InlineData("13 players; last marble is worth 7999 points", 146373)]
        [InlineData("17 players; last marble is worth 1104 points", 2764)]
        [InlineData("21 players; last marble is worth 6111 points", 54718)]
        [InlineData("30 players; last marble is worth 5807 points", 37305)]
        public void Part01(string input, int expected) 
        {
            // Act
            var actual = Day09.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day09.ReadInput();

            // Act
            var actual = Day09.Part01(input);

            // Assert
            Assert.Equal(394486, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange

            // Act

            // Assert
        }
    }
}
