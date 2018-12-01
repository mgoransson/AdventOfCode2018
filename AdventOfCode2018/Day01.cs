using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day01
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day01.input.txt");
        }

        public static int Part01(string[] input)
        {
            return input.Sum(x => int.Parse(x));
        }

        public static int Part02(string[] input)
        {
            var frequency = 0;
            var reachedFrequencies = new HashSet<int>();
            var currentFrequencyIndex = 0;
            while (!reachedFrequencies.Contains(frequency))
            {
                reachedFrequencies.Add(frequency);
                frequency += int.Parse(input[currentFrequencyIndex]);
                currentFrequencyIndex = (currentFrequencyIndex + 1) % input.Length;
            }
            return frequency;
        }
    }
}
