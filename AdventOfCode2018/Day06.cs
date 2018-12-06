using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day06
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            Console.WriteLine("Part II");
            Console.WriteLine(Part02(input, 10000));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day06.input.txt");
        }

        public static int Part01(string[] input)
        {
            var inputCoordinates = ParseCoordinates(input);
            (var minX, var minY, var maxX, var maxY) = GetEdges(inputCoordinates);

            var coordinates = new List<Coordinate>();
            var edgeNames = new List<string>();
            for (var y = minY; y < maxY; y++)
            {
                for (var x = minX; x < maxX; x++)
                {
                    var distancesToInputCoordinates = new Dictionary<string, int>();
                    foreach(var inputCoordinate in inputCoordinates)
                    {
                        distancesToInputCoordinates.Add(inputCoordinate.Name, ManhattanDistance(x, inputCoordinate.X, y, inputCoordinate.Y));
                    }

                    var closestInputCoordinate = distancesToInputCoordinates.OrderBy(o => o.Value).First();
                    var closestInputCoordinateName = distancesToInputCoordinates.Count(c => c.Value == closestInputCoordinate.Value) > 1 ? "." : closestInputCoordinate.Key;
                    coordinates.Add(new Coordinate() 
                    {
                        Name = closestInputCoordinateName,
                        X = x,
                        Y = y
                    });

                    // Check if edge
                    if (y == minY || y == maxY)
                    {
                        if (!edgeNames.Contains(closestInputCoordinateName))
                        {
                            edgeNames.Add(closestInputCoordinateName);
                        }
                    }
                    else
                    {
                        if (x == minX || x == maxX - 1)
                        {
                            if (!edgeNames.Contains(closestInputCoordinateName))
                            {
                                edgeNames.Add(closestInputCoordinateName);
                            }
                        }
                    }
                }
            }

            foreach(var edgeName in edgeNames)
            {
                coordinates.RemoveAll(p => p.Name == edgeName);
            }

            return coordinates.GroupBy(x => x.Name)
                .Select(g => new 
                    { 
                        Key = g, 
                        Count = g.Count()
                    })
                .Max(x => x.Count);
        }

        public static int Part02(string[] input, int maxSum)
        {
            var inputCoordinates = ParseCoordinates(input);
            (var minX, var minY, var maxX, var maxY) = GetEdges(inputCoordinates);

            var coordinates = new List<Coordinate>();
            var regionSize = 0;
            for (var y = minY; y < maxY; y++)
            {
                for (var x = minX; x < maxX; x++)
                {
                    var sum = 0;
                    foreach(var inputCoordinate in inputCoordinates)
                    {
                        sum += ManhattanDistance(x, inputCoordinate.X, y, inputCoordinate.Y);
                    }
                    if (sum < maxSum)
                        regionSize++;
                }
            }

            return regionSize;
        }

        private static List<Coordinate> ParseCoordinates(string[] input)
        {
            var inputCoordinates = new List<Coordinate>();
            var a = "ABCDEFghijklmnopqrstuvwxyz1234567890!#€%&/()=?<>;:-+*_@|£$";
            for (var i = 0; i < input.Length; i++)
            {
                inputCoordinates.Add(new Coordinate() {
                    Name = a[i].ToString(),
                    X = int.Parse(input[i].Split(',')[0].Trim()),
                    Y = int.Parse(input[i].Split(',')[1].Trim())
                });
            }
            return inputCoordinates;
        }

        private static (int, int, int, int) GetEdges(List<Coordinate> coordinates)
        {
            var minX = 0;
            var minY = 0;
            var maxX = coordinates.Max(p => p.X) + 2;
            var maxY = coordinates.Max(p => p.Y) + 1;
            return (minX, minY, maxX, maxY);
        }

        private  static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        class Coordinate
        {
            public string Name { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
