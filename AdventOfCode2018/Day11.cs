using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day11
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
            return File.ReadAllText(@"Inputs/Day11.input.txt");
        }

        public static (int X, int Y) Part01(string input)
        {
            var serialNumber = int.Parse(input);
            var grid = FillFuelCells(serialNumber);

            var topLeft = GetLargestSquarePoint(grid, 3);
            return (topLeft.X, topLeft.Y);
        }

        public static (int X, int Y, int squareSize) Part02(string input)
        {
            var serialNumber = int.Parse(input);
            var grid = FillFuelCells(serialNumber);

            var resultPoint = new Point();
            for (var i = 1; i <= 300; i++)
            {
                var result = GetLargestSquarePoint(grid, i);
                if (resultPoint.PowerLevel < result.PowerLevel)
                {
                    resultPoint = result;
                }

                if (result.PowerLevel < 0)
                {
                    return (resultPoint.X, resultPoint.Y, resultPoint.SquareSize);
                }
            }

            return (resultPoint.X, resultPoint.Y, resultPoint.SquareSize);
        }

        private static Dictionary<(int, int), int> FillFuelCells(int input)
        {
            var fuelCells = new Dictionary<(int, int), int>();
            for (var x = 1; x <= 300; x++)
            {
                for (var y = 1; y <= 300; y++)
                {
                    var rackID = x + 10;
                    var powerLevel = rackID * y;
                    powerLevel += input;
                    powerLevel *= rackID;
                    int hundredDigitOfPowerLevel = (int)Math.Abs(powerLevel / 100 % 10);
                    hundredDigitOfPowerLevel -= 5;

                    fuelCells.Add((x, y), hundredDigitOfPowerLevel);
                }
            }
            return fuelCells;
        }

        private static Point GetLargestSquarePoint(Dictionary<(int, int), int> grid, int squareSize)
        {
            var topLefts = new HashSet<Point>();
            for(var y = 1; y < 300 - squareSize; y++)
            {
                for(var x = 1; x < 300 - squareSize; x++)
                {
                    var total = 0;
                    for(var innerY = y; innerY < y + squareSize; innerY++)
                    {
                        for(var innerX = x; innerX < x + squareSize; innerX++)
                        {
                            total += grid[(innerX, innerY)];
                        }
                    }
                    topLefts.Add(new Point()
                    {
                        X = x,
                        Y = y,
                        PowerLevel = total,
                        SquareSize = squareSize
                    });
                }
            }
            return topLefts.OrderByDescending(x => x.PowerLevel).First();
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int PowerLevel { get; set; }
            public int SquareSize { get; set; }
        }
    }
}
