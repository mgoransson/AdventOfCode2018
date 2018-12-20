using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day13Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new []
            {
                @"/->-\        ",
                @"|   |  /----\",
                @"| /-+--+-\  |",
                @"| | |  | v  |",
                @"\-+-/  \-+--/",
                @"  \------/    "
            };

            // Act
            var actual = Day13.Part01(input);

            // Assert
            Assert.Equal("7,3", actual);
        }

        [Fact]
        public void Part01_Answer() 
        {
            // Arrange
            var input = Day13.ReadInput();

            // Act
            var actual = Day13.Part01(input);

            // Assert
            Assert.Equal("129,50", actual);
        }


        [Fact]
        public void Part02() 
        {
            // Arrange
            var input = new []
            {
                @"/>-<\  ",
                @"|   |  ",
                @"| /<+-\",
                @"| | | v",
                @"\>+</ |",
                @"  |   ^",
                @"  \<->/"
            };

            // Act
            var actual = Day13.Part02(input);

            // Assert
            Assert.Equal("6,4", actual);
        }

        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day13.ReadInput();

            // Act
            var actual = Day13.Part02(input);

            // Assert
            Assert.Equal("69,73", actual);
        }
    }
}
