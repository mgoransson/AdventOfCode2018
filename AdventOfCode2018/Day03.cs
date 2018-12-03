using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day03
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
            return File.ReadAllLines(@"Inputs/Day03.input.txt");
        }

        public static int Part01(string[] input)
        {
            return Solve(input).numOfOverlapedClaims;
        }

        public static int Part02(string[] input)
        {
            return Solve(input).notOverlapedId;
        }

        private static (int numOfOverlapedClaims, int notOverlapedId) Solve(string[] input)
        {
            var claims = new Dictionary<(int, int), List<string>>();
            var notOverlapedIds = new HashSet<string>();

            foreach(var claim in input)
            {
                var id = claim.Split(" ")[0];
                notOverlapedIds.Add(id);
                var inchesFromLeft = int.Parse(claim.Split(" ")[2].Split(",")[0]);
                var inchesFromTop = int.Parse(claim.Split(" ")[2].Split(",")[1].Trim(':'));
                var width = int.Parse(claim.Split(" ")[3].Split("x")[0]);
                var height = int.Parse(claim.Split(" ")[3].Split("x")[1]);

                for(var h = 0; h < height; h++)
                {
                    for(var w = 1; w <= width; w++)
                    {
                        var x = (inchesFromLeft ) + w;
                        var y = (0 - inchesFromTop) - h;

                        if (claims.ContainsKey((x, y)))
                        {
                            var claimsValue = claims.GetValueOrDefault((x, y));
                            claimsValue.Add(id);
                            claims[(x, y)] = claimsValue;

                            notOverlapedIds.RemoveWhere(i => claimsValue.Contains(i));
                        }
                        else
                        {
                            claims.Add((x, y), new List<string>() { id });
                        }
                    }
                }
            }
            var numOfOverlapedClaims = claims.Values.Count(v => v.Count() > 1);
            var notOverlapedId = int.Parse(notOverlapedIds.FirstOrDefault().Trim('#'));

            return (numOfOverlapedClaims, notOverlapedId);
        }
    }
}
