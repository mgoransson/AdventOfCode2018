using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "initial state: #..#.#..##......###...###",
                "",
                "...## => #",
                "..#.. => #",
                ".#... => #",
                ".#.#. => #",
                ".#.## => #",
                ".##.. => #",
                ".#### => #",
                "#.#.# => #",
                "#.### => #",
                "##.#. => #",
                "##.## => #",
                "###.. => #",
                "###.# => #",
                "####. => #"
            };

            // Act
            var actual = Day12.Part01(input);

            // Assert
            Assert.Equal(325, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {
            // Arrange
            var input = Day12.ReadInput();

            // Act
            var actual = Day12.Part01(input);

            // Assert
            Assert.Equal(2917, actual);
        }


        [Fact]
        public void Part02_Answer() 
        {
            // Arrange
            var input = Day12.ReadInput();

            // Act
            var actual = Day12.Part02(input);

            // Assert
            Assert.Equal(3250000000956, actual);
        }
    }
}
