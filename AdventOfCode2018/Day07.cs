using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day07
    {
        public static void Run()
        {
            var input = ReadInput();

            Console.WriteLine("Part I: ");
            Console.WriteLine(Part01(input));

            // Console.WriteLine("Part II");
            // Console.WriteLine(Part02(input));
        }

        public static string[] ReadInput() 
        {
            return File.ReadAllLines(@"Inputs/Day07.input.txt");
        }

        public static string Part01(string[] input)
        {
            var instructions = new Dictionary<string, List<string>>();
            var requirements = new List<string>();
            foreach(var line in input)
            {
                var key = line.Split(" ")[1];
                var value = line.Split(" ")[7];
                if (!instructions.ContainsKey(key))
                {
                    instructions.Add(key, new List<string>() { value });
                }
                else
                {
                    instructions[key].Add(value);
                }

                if (!requirements.Contains(value))
                {
                    requirements.Add(value);
                }
            }

            var instructionKeys = instructions.Select(x => x.Key).ToList();            
            instructionKeys.RemoveAll(x => requirements.Contains(x));
            var currentStep = instructionKeys.First();
            var availableSteps = new List<string>();
            var finishedSteps = new List<string>();
            var result = "";
            while(true)
            {
                finishedSteps.Add(currentStep);
                result += currentStep;

                if (instructions.ContainsKey(currentStep))
                {
                    foreach(var x in instructions[currentStep])
                    {
                        if (!availableSteps.Contains(x))
                        {
                            availableSteps.Add(x);
                        }
                    }
                    availableSteps.RemoveAll(x => finishedSteps.Contains(x));

                    var orderedAvailableSteps = availableSteps.OrderBy(x => x);
                    foreach(var step in orderedAvailableSteps)
                    {
                        // get all keys that have step in value
                        var keysWithStep = instructions.Where(x => x.Value.Contains(step)).Select(x => x.Key);
                        // check if all keys in keysWithStep are finished (exists in finished)
                        // if all keys exist -> set currentSetp to step else continue loop
                        if (keysWithStep.Count(x => finishedSteps.Contains(x)) == keysWithStep.Count())
                        {
                            currentStep = step;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        // public static int Part02(string[] input)
        // {
        //     return 1;
        // }
    }
}
