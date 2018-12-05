using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day05Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = "dabAcCaCBAcCcaDA";

            // Act
            var actual = Day05.Part01(input);

            // Assert
            Assert.Equal(10, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day05.ReadInput();

            // Act
            var actual = Day05.Part01(input);

            // Assert
            Assert.Equal(11298, actual);
        }


        [Fact]
        public void Part02() 
        {
             // Arrange
            var input = "dabAcCaCBAcCcaDA";

            // Act
            var actual = Day05.Part02(input);

            // Assert
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day05.ReadInput();

            // Act
            var actual = Day05.Part02(input);

            // Assert
            Assert.Equal(5148, actual);
        }
    }
}
