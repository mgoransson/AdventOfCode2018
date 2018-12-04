using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day04
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
            return File.ReadAllLines(@"Inputs/Day04.input.txt");
        }

        public static int Part01(string[] input)
        {
            var records = ExtractRecords(input);
            var guards = ProcessRecords(records);

            var guardWithMostMinutesAsleep = guards
                .OrderByDescending(g => g.Value.TotalMinutesAsleep)
                .First();
            var guardsMostAsleepMinute = guardWithMostMinutesAsleep
                        .Value
                        .SleepMinuteMap
                        .OrderByDescending(sm => sm.Value)
                        .First().Key;

            return guardWithMostMinutesAsleep.Key * guardsMostAsleepMinute;
        }

        public static int Part02(string[] input)
        {
            var records = ExtractRecords(input);
            var guards = ProcessRecords(records);

            var guard = guards.OrderByDescending(g => g.Value.SleepMinuteMap.OrderByDescending(sm => sm.Value).First().Value).First();
            return guard.Key * guard.Value.SleepMinuteMap.OrderByDescending(sm => sm.Value).First().Key;
        }

        private static List<Record> ExtractRecords(string[] input)
        {
            var records = new List<Record>();
            foreach(var row in input)
            {
                records.Add(new Record()
                {
                    Date = DateTime.Parse(row.Split(']', StringSplitOptions.RemoveEmptyEntries)[0].Trim('[')),
                    Value = row.Split(']')[1].Trim(' ')
                });
            }
            return records.OrderBy(x => x.Date).ToList();
        }

        private static Dictionary<int, Guard> ProcessRecords(List<Record> records)
        {
            var guards = new Dictionary<int, Guard>();
            var currentGuardId = 0;
            var fallsAsleep = new DateTime();
            foreach(var record in records)
            {
                switch(record.Value.Split(" ")[0].ToLower())
                {
                    case "guard":
                        currentGuardId = int.Parse(record.Value.Split(" ")[1].Trim('#'));
                        if (!guards.ContainsKey(currentGuardId))
                        {
                            guards.Add(currentGuardId, new Guard());
                        }
                    break;
                    case "falls":
                        fallsAsleep = record.Date;
                    break;
                    case "wakes":
                        for (int i = fallsAsleep.Minute; i < record.Date.Minute; i++)
                        {
                            guards[currentGuardId].SleepMinuteMap[i] += 1;
                            guards[currentGuardId].TotalMinutesAsleep += 1;
                        }
                    break;
                }
            }

            return guards;
        }

        class Guard
        {
            public Guard()
            {
                SleepMinuteMap = Enumerable.Range(0, 59)
                    .ToDictionary(x => x, x => 0);
            }

            public int TotalMinutesAsleep { get; set; }
            public Dictionary<int, int> SleepMinuteMap { get; set; }
        }

        class Record
        {
            public DateTime Date { get; set; }
            public string Value { get; set; }
        }
    }
}
