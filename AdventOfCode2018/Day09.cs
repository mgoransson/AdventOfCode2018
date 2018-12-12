using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day09
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            // Console.WriteLine("Part II");
            // Console.WriteLine(Part02(input));
        }

        public static string ReadInput() 
        {
            return File.ReadAllText(@"Inputs/Day09.input.txt");
        }

        public static int Part01(string input)
        {
            var playerCount = int.Parse(input.Split(" ")[0]);
            var lastMarble = int.Parse(input.Split(" ")[6]);

            var players = Enumerable.Range(1, playerCount).ToDictionary(p => p, p => 0);

            var marbles = new List<int>();
            marbles.Insert(0, 0);
            var currentMarbleIndex = 1;
            var currentPlayerIndex = 0;
            for(var i = 0; i <= lastMarble; i++)
            {
                if (i % 23 != 0)
                {
                    currentMarbleIndex = (currentMarbleIndex + 2) % marbles.Count;
                    marbles.Insert(currentMarbleIndex, i);
                }
                else
                {
                    if (i > 0)
                    {                        
                        var indexToRemove = ((currentMarbleIndex + marbles.Count) - 7) % marbles.Count;

                        players[currentPlayerIndex + 1] += i + marbles[indexToRemove];
                        marbles.RemoveAt(indexToRemove);
                        currentMarbleIndex = indexToRemove % marbles.Count;
                    }
                }

                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count();
            }

            return players.Max(x => x.Value);
        }

        // public static int Part02(string input)
        // {
        //     return 1;
        // }
    }
}
