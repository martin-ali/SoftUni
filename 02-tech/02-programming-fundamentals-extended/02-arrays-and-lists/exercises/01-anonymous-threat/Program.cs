using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_anonymous_threat
{
    class Program
    {
        private static Dictionary<string, Func<(int, int), List<string>, List<string>>> execute =
        new Dictionary<string, Func<(int, int), List<string>, List<string>>>
        {
            ["merge"] = Merge,
            ["divide"] = Divide
        };

        static void Main()
        {
            var data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToList();
            var rawCommand = Console.ReadLine().ToLower();

            while (rawCommand != "3:1")
            {
                // Golden hammer ftw
                var commandComponents = rawCommand.Split(new char[] { ' ' }, StringSplitOptions.None);
                var command = (type: commandComponents[0], start: int.Parse(commandComponents[1]), end: int.Parse(commandComponents[2]));

                data = execute[command.type]((command.start, command.end), data);
                rawCommand = Console.ReadLine().ToLower();
            }

            Console.WriteLine(String.Join(" ", data));
        }

        private static List<string> Merge((int start, int end) merge, List<string> data)
        {
            var newData = new List<string>();
            var start = Clamp(0, merge.start, data.Count - 1);
            var end = Clamp(0, merge.end, data.Count - 1);

            for (int index = 0; index < start; index++)
            {
                newData.Add(data[index]);
            }

            string partition = "";
            for (int index = start; index <= end; index++)
            {
                partition += data[index];
            }
            newData.Add(partition);

            for (int index = end + 1; index < data.Count; index++)
            {
                newData.Add(data[index]);
            }

            return newData;
        }

        private static List<string> Divide((int start, int partitions) division, List<string> data)
        {
            var modifiedData = new List<string>();
            division.partitions = Math.Min(division.partitions, data[division.start].Length);

            for (int index = 0; index < division.start; index++)
            {
                modifiedData.Add(data[index]);
            }

            var partitions = SplitIntoPartitions(division.partitions, data[division.start]);
            var newIndex = division.start;
            foreach (var partition in partitions)
            {
                modifiedData.Add(partition);
            }

            for (int index = division.start + 1; index < data.Count; index++)
            {
                modifiedData.Add(data[index]);
            }

            return modifiedData;
        }

        private static List<string> SplitIntoPartitions(int partitionsCount, string str)
        {
            var partitions = new List<string>();
            var partitionSize = str.Length / partitionsCount;

            var partitionIndex = 0;
            var currentPartition = 0;
            while (currentPartition < partitionsCount - 1)
            {
                partitions.Add(str.Substring(partitionIndex, partitionSize));
                partitionIndex += partitionSize;
                currentPartition++;
            }

            partitions.Add(str.Substring(partitionIndex));

            return partitions;
        }

        private static int Clamp(int startBound, int number, int endBound)
        {
            if (number < startBound)
            {
                number = startBound;
            }
            else if (number > endBound)
            {
                number = endBound;
            }

            return number;
        }
    }
}
