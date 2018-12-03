using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

            // Act
            var actual = Day03.Part01(input);

            // Assert
            Assert.Equal(4, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day03.ReadInput();

            // Act
            var actual = Day03.Part01(input);

            // Assert
            Assert.Equal(101469, actual);
        }


        [Fact]
        public void Part02() 
        {
             // Arrange
            var input = new [] {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

            // Act
            var actual = Day03.Part02(input);

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day03.ReadInput();

            // Act
            var actual = Day03.Part02(input);

            // Assert
            Assert.Equal(1067, actual);
        }
    }
}
