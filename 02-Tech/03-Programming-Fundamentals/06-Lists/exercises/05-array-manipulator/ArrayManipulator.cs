using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_array_manipulator
{
    class ArrayManipulator
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                switch (command[0])
                {
                    case "add":
                        {
                            var index = int.Parse(command[1]);
                            var number = int.Parse(command[2]);
                            numbers.Insert(index, number);
                            break;
                        }
                    case "addMany":
                        {
                            var index = int.Parse(command[1]);
                            var newNumbers = command.Skip(2).Select(int.Parse).ToList();
                            numbers.InsertRange(index, newNumbers);
                            break;
                        }
                    case "contains":
                        {
                            var item = int.Parse(command[1]);
                            var numberIndex = numbers.IndexOf(item);
                            Console.WriteLine(numberIndex);
                            break;
                        }
                    case "remove":
                        {
                            var index = int.Parse(command[1]);
                            numbers.RemoveAt(index);
                            break;
                        }
                    case "shift":
                        {
                            var rotations = int.Parse(command[1]);
                            numbers.ShiftLeft(rotations);
                            break;
                        }
                    case "sumPairs":
                        {
                            numbers = numbers.SumPairs();
                            break;
                        }
                    case "print":
                        {
                            numbers.Print();
                            return;
                        }
                }
            }
        }
    }

    public static class ListExtensions
    {
        public static void ShiftLeft(this List<int> arr, int positions)
        {
            positions = positions % arr.Count;

            // Loop variant
            var original = arr.ToList();
            for (int i = 0; i < arr.Count; i++)
            {
                var newIndex = i + positions;
                if (newIndex >= arr.Count) newIndex -= arr.Count;
                arr[i] = original[newIndex];
            }

            // LINQ variant
            // var left = arr.Skip(positions);
            // var right = arr.Take(positions);
            // var shiftedArr = left.Concat(right).ToList();
            // return shiftedArr;
        }

        public static List<int> SumPairs(this List<int> arr)
        {
            var summedPairs = new List<int>();
            var end = (arr.Count / 2) * 2;
            for (int i = 0; i < end; i += 2)
            {
                var sum = arr[i] + arr[i + 1];
                summedPairs.Add(sum);
            }

            bool arrCountIsOdd = arr.Count % 2 != 0;
            if (arrCountIsOdd)
            {
                summedPairs.Add(arr.Last());
            }

            return summedPairs;
        }

        public static void Print(this List<int> arr)
        {
            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }
    }
}
/*

1 2 4 5 6 7
add 1 8
contains 1
contains -3
print

1 2 3 4 5
addMany 5 9 8 7 6 5
contains 15
remove 3
shift 1
print

2 2 4 2 4
add 1 4
sumPairs
print

1 2 1 2 1 2 1 2 1 2 1 2
sumPairs
sumPairs
addMany 0 -1 -2 -3
print

 */
