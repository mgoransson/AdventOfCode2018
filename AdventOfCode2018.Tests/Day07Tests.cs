using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };

            // Act
            var actual = Day07.Part01(input);

            // Assert
            Assert.Equal("CABDFE", actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day07.ReadInput();

            // Act
            var actual = Day07.Part01(input);

            // Assert
            Assert.Equal("SCLPAMQVUWNHODRTGYKBJEFXZI", actual);
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
