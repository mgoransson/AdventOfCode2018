using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day01Tests
    {
        [Theory]
        [InlineData(new [] {"+1", "+1", "+1"}, 3)]
        [InlineData(new [] {"+1", "+1", "-2"}, 0)]
        [InlineData(new [] {"-1", "-2", "-3"}, -6)]
        public void Part01(string[] input, int expected) 
        {
            // Act
            int actual = Day01.Part01(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day01.ReadInput();

            // Act
            var actual = Day01.Part01(input);

            // Assert
            Assert.Equal(435, actual);
        }


        [Theory]
        [InlineData(new [] {"+1", "-1"}, 0)]
        [InlineData(new [] {"+3", "+3", "+4", "-2", "-4"}, 10)]
        [InlineData(new [] {"-6", "+3", "+8", "+5", "-6"}, 5)]
        [InlineData(new [] {"+7", "+7", "-2", "-7", "-4"}, 14)]
        public void Part02(string[] input, int expected) 
        {
            // Act
            int actual = Day01.Part02(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day01.ReadInput();

            // Act
            var actual = Day01.Part02(input);

            // Assert
            Assert.Equal(245, actual);
        }
    }
}
