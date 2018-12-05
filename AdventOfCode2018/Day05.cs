using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day05
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day05.input.txt");
        }

        public static int Part01(string input)
        {
            var polymer = ProcessPolymer(input);
            return polymer.Length;
        }

        public static int Part02(string input)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var polymers = new Dictionary<char, string>();

            foreach(var c in alpha)
            {
                polymers.Add(c, ProcessPolymer(input.Replace(c.ToString().ToUpper(), "").Replace(c.ToString().ToLower(), "")));
            }

            return polymers.OrderBy(x => x.Value.Length).First().Value.Length;
        }

        private static string ProcessPolymer(string polymer)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            while (true)
            {
                var removed = false;
                foreach(var c in alpha)
                {
                    var lowerUpper = c.ToString().ToLower() + c.ToString().ToUpper();
                    var upperLower = c.ToString().ToUpper() + c.ToString().ToLower();
                    if (polymer.Contains(lowerUpper) || polymer.Contains(upperLower))
                    {
                        polymer = polymer.Replace(lowerUpper, "").Replace(upperLower, "");
                        removed = true;
                    }
                }
                if (!removed)
                    break;
            }

            return polymer;
        }
    }
}
