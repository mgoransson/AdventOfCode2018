using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day12
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
            return File.ReadAllLines(@"Inputs/Day12.input.txt");
        }

        public static long Part01(string[] input)
        {
            var currentState = input[0].Split(" ")[2];
            var notes = GetNotes(input);

            var generations = new HashSet<Generation>();
            generations.Add(new Generation() { Id = 0, State = currentState, SumPlants = GetSumOfPots(currentState, 0) });
            for (var i = 1; i <= 20; i++)
            {
                currentState = GetNextState(notes, currentState);
                generations.Add(new Generation() {
                    Id = i,
                    State = currentState,
                    SumPlants = GetSumOfPots(currentState, i)
                });
            }
            return generations.Last().SumPlants;
        }

        public static long Part02(string[] input)
        {
            var currentState = input[0].Split(" ")[2];
            var notes = GetNotes(input);

            var generations = new HashSet<Generation>();
            generations.Add(new Generation() { Id = 0, State = currentState, SumPlants = GetSumOfPots(currentState, 0) });
            var prevDiff = 0L;
            var prevDiffCount = 0;
            for (var i = 1; i <= int.MaxValue; i++)
            {
                currentState = GetNextState(notes, currentState);
                generations.Add(new Generation()
                {
                    Id = i,
                    State = currentState,
                    SumPlants = GetSumOfPots(currentState, i)
                });

                if (generations.Count > 1)
                {
                    var diff = generations.Single(x => x.Id == i).SumPlants - generations.Single(x => x.Id == (i - 1)).SumPlants;
                    prevDiffCount = prevDiff == diff ? prevDiffCount + 1 : 0;

                    if (prevDiffCount > 10)
                    {
                        break;
                    }
                    prevDiff = diff;
                }
            }

            return ((50000000000 - generations.Last().Id) * prevDiff) + generations.Last().SumPlants;
        }

        private static long GetSumOfPots(string state, long index)
        {
            var startIndex = (index * 3) * (-1);
            var sum = 0L;
            for (var i = 0; i < state.Length; i++)
            {
                if (state.ToCharArray()[i] == '#')
                {
                    sum += (i + startIndex);
                }
            }

            return sum;
        }

        private static List<int> GetIndexes(string str, string value)
        {
            var indexs = new List<int>();
            int start = 0;
            int index;
            while ((index = str.IndexOf(value, start)) >= 0)
            {
                indexs.Add(index);
                start = index + 1;
            }
            return indexs;
        }

        private static Dictionary<string, string> GetNotes(string[] input)
        {
            var notes = new Dictionary<string, string>();
            foreach(var line in input.Take(input.Length).Skip(2))
            {
                notes.Add(line.Split("=>")[0].Trim(), line.Split("=>")[1].Trim());
            }
            return notes;
        }

        private static string GetNextState(Dictionary<string, string> notes, string currentState)
        {
            var indexes = new Dictionary<int, string>();
            currentState = "..." + currentState;
            currentState = currentState + "...";
            foreach(var note in notes)
            {
                var idxs = GetIndexes(currentState, note.Key);
                foreach(var idx in idxs)
                {
                    if (note.Value == "#")
                    {
                        if (!indexes.ContainsKey(idx + 2))
                        {
                            indexes.Add(idx + 2, note.Value);
                        }
                    }
                }
            }

            var nextState = Enumerable.Range(0, currentState.Length).ToList().Select(x => ".").ToList();
            foreach(var index in indexes)
            {
                nextState[index.Key] = index.Value;
            }
            return String.Join("", nextState);
        }

        class Generation
        {
            public long Id { get; set; }
            public string State { get; set; }
            public long SumPlants { get; set; }
        }
    }
}
