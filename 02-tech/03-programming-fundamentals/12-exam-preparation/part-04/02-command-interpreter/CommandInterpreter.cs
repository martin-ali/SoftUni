using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_command_interpreter
{
    class CommandInterpreter
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                var parameters = input.Split();
                var operation = parameters[0];

                if (operation.Contains("roll"))
                {
                    var positions = int.Parse(parameters[1]);

                    if (positions < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    positions %= numbers.Count;
                    if (operation == "rollLeft")
                    {
                        numbers = ShiftLeft(collection: numbers, positions: positions);
                    }
                    else // if (operation == "rollRight)
                    {
                        numbers = ShiftRight(collection: numbers, positions: positions);
                    }
                }
                else
                {
                    var start = int.Parse(parameters[2]);
                    var count = int.Parse(parameters[4]);

                    var anyParameterIsInvalid = start < 0
                                            || start >= numbers.Count
                                            || start + count > numbers.Count
                                            || count < 0;
                    if (anyParameterIsInvalid)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        continue;
                    }

                    if (operation == "reverse")
                    {
                        numbers.Reverse(start, count);
                    }
                    else // if (operation == "sort")
                    {
                        numbers.Sort(start, count, null);
                    }
                }
            }

            Console.WriteLine($"[{String.Join(", ", numbers)}]");
        }

        private static List<string> ShiftLeft(List<string> collection, int positions)
        {

            var leftSide = collection.Skip(positions);
            var rightSide = collection.Take(positions);

            return leftSide.Concat(rightSide).ToList();
        }

        private static List<string> ShiftRight(List<string> collection, int positions)
        {
            var leftSide = collection.Skip(collection.Count - positions);
            var rightSide = collection.Take(collection.Count - positions);

            return leftSide.Concat(rightSide).ToList();
        }

        private static bool IsValidIndex(int index, int collectionLength)
        {
            if (0 <= index && index < collectionLength)
            {
                return true;
            }

            return false;
        }
    }
}