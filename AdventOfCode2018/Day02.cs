using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day02
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
            return File.ReadAllLines(@"Inputs/Day02.input.txt");
        }

        public static int Part01(string[] input)
        {
            var twoOfAnyLetter = 0;
            var threeOfAnyLetter = 0;
            foreach(var boxId in input)
            {
                twoOfAnyLetter += StringContainsXOfAnyLetter(boxId, 2) ? 1 : 0;

                threeOfAnyLetter += StringContainsXOfAnyLetter(boxId, 3) ? 1 : 0;
            }

            return twoOfAnyLetter * threeOfAnyLetter;
        }

        public static string Part02(string[] input)
        {
            var orderedInput = input.OrderBy(x => x).Select(x => x).ToList();
            var commonLetters = string.Empty;

            for (var i = 0; i < orderedInput.Count() - 1; i++)
            {
                for (var j = i + 1; j < orderedInput.Count() - 1; j++)
                {
                    var c = CountCommonCharacters(orderedInput[i], orderedInput[j]);
                    if (orderedInput[i].Length - c == 1)
                    {
                        commonLetters = CreateCommonString(orderedInput[i], orderedInput[j]);
                        break;
                    }
                }
            }

            return commonLetters;
        }

        private static bool StringContainsXOfAnyLetter(string str, int x)
        {
            return str.GroupBy(c => c)
                .Select(group => new
                {
                    Key = group.Key,
                    Count = group.Count()
                }).Any(c => c.Count == x);
        }

        private static int CountCommonCharacters(string s1, string s2)
        {
            var commonCount = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1.ToCharArray()[i] == s2.ToCharArray()[i])
                {
                    commonCount++;
                }
            }

            return commonCount;
        }

        private static string CreateCommonString(string s1, string s2)
        {
            var common = string.Empty;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1.ToCharArray()[i] == s2.ToCharArray()[i])
                {
                    common += s1.ToCharArray()[i];
                }
            }

            return common;
        }
    }
}
