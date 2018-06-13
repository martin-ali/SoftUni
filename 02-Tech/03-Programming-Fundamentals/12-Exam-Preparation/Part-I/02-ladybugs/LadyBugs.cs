using System;
using System.IO;
using System.Linq;

namespace _02_ladybugs
{
    class LadyBugs
    {
        static void Main()
        {
            #if DEBUG
            Console.SetIn(new StreamReader("tests/test4.txt"));
            #endif

            var fieldSize = int.Parse(Console.ReadLine());
            var initialPositions = Console
                                    .ReadLine()
                                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                    .Where(x => CoordinatesAreValid(x, fieldSize));

            var field = new byte[fieldSize];
            foreach (var coordinate in initialPositions)
            {
                field[coordinate] = 1;
            }

            var input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                var ladybug = int.Parse(input[0]);
                var direction = input[1];
                var flight = int.Parse(input[2]);

                if (direction == "left") flight *= -1;
                var target = ladybug + flight;

                if (CoordinatesAreValid(ladybug, field.Length) && field[ladybug] == 1)
                {
                    field[ladybug] = 0;
                    while (CoordinatesAreValid(target, field.Length) && field[target] == 1)
                    {
                        target += flight;
                    }

                    if (CoordinatesAreValid(target, field.Length))
                    {
                        field[target] = 1;
                    }
                }

                input = Console.ReadLine().Split();
            }

            var result = string.Join(" ", field);
            Console.WriteLine(result);
        }

        private static bool CoordinatesAreValid(int ladybug, int end)
        {
            return (0 <= ladybug && ladybug < end);
        }
    }
}
