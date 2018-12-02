using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };

            // Act
            var actual = Day02.Part01(input);

            // Assert
            Assert.Equal(12, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day02.ReadInput();

            // Act
            var actual = Day02.Part01(input);

            // Assert
            Assert.Equal(4693, actual);
        }


        [Fact]
        public void Part02() 
        {
             // Arrange
            var input = new [] {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };

            // Act
            var actual = Day02.Part02(input);

            // Assert
            Assert.Equal("fgij", actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day02.ReadInput();

            // Act
            var actual = Day02.Part02(input);

            // Assert
            Assert.Equal("pebjqsalrdnckzfihvtxysomg", actual);
        }
    }
}
