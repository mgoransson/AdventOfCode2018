using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day08
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
            return File.ReadAllText(@"Inputs/Day08.input.txt");
        }

        public static int Part01(string input)
        {
            var parsedInput = input.Split(" ").Select(x => int.Parse(x)).ToArray();
            var index = 0;
            var tree = BuildNode(parsedInput, ref index);

            return GetMetadataSum(tree);
        }

        public static int Part02(string input)
        {
            var parsedInput = input.Split(" ").Select(x => int.Parse(x)).ToArray();
            var index = 0;
            var tree = BuildNode(parsedInput, ref index);

            return tree.Value;
        }

        private static Node BuildNode(int[] input, ref int index)
        {
            var node = new Node();
            var childrenCount = input[index];
            index++;
            var metadataCount = input[index];

            for (var i = 0; i < childrenCount; i++)
            {
                index++;
                var child = BuildNode(input, ref index);
                node.Children.Add(child);
            }

            for (int i = 0; i < metadataCount; i++)
            {
                index++;
                var metadataValue = input[index];
                node.Metadata.Add(metadataValue);

                if (childrenCount == 0)
                {
                    node.Value += metadataValue;
                }
                else
                {
                    if (metadataValue > 0 && metadataValue <= childrenCount)
                    {
                        node.Value += node.Children[metadataValue - 1].Value;
                    }
                }
            }

            return node;
        }

        private static int GetMetadataSum(Node node)
        {
            var sum = node.Metadata.Sum();
            foreach(var child in node.Children)
            {
                sum += GetMetadataSum(child);
            }
            return sum;
        }

        class Node
        {
            public List<Node> Children { get; set; }
            public List<int> Metadata { get; set; }
            public int Value { get; set; }

            public Node()
            {
                Children = new List<Node>();
                Metadata = new List<int>();
            }
        }
    }
}
