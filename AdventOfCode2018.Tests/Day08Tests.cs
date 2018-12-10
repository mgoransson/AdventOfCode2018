using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            // Act
            var actual = Day08.Part01(input);

            // Assert
            Assert.Equal(138, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day08.ReadInput();

            // Act
            var actual = Day08.Part01(input);

            // Assert
            Assert.Equal(40984, actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

            // Act
            var actual = Day08.Part02(input);

            // Assert
            Assert.Equal(66, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day08.ReadInput();

            // Act
            var actual = Day08.Part02(input);

            // Assert
            Assert.Equal(37067, actual);
        }
    }
}
