using System;
using Xunit;

namespace AdventOfCode2018.Tests
{
    public class Day04Tests
    {
        [Fact]
        public void Part01() 
        {
            // Arrange
            var input = new [] {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };

            // Act
            var actual = Day04.Part01(input);

            // Assert
            Assert.Equal(240, actual);
        }

        [Fact]
        public void Part01_Answer() 
        {            
            // Arrange
            var input = Day04.ReadInput();

            // Act
            var actual = Day04.Part01(input);

            // Assert
            Assert.Equal(98680, actual);
        }


        [Fact]
        public void Part02() 
        {
             // Arrange
            var input = new [] {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };

            // Act
            var actual = Day04.Part02(input);

            // Assert
            Assert.Equal(4455, actual);
        }

        [Fact]
        public void Part02_Answer() 
        {            
            // Arrange
            var input = Day04.ReadInput();

            // Act
            var actual = Day04.Part02(input);

            // Assert
            Assert.Equal(9763, actual);
        }
    }
}
