using System;

namespace Rhombus_Of_Stars
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            for (int current = 1; current <= size; current++)
            {
                Console.WriteLine(DrawLineWithIntervalsAndPadding("*", current, size - current));
            }

            for (int current = size - 1; current > 0; current--)
            {
                Console.WriteLine(DrawLineWithIntervalsAndPadding("*", current, size - current));
            }
        }

        static string DrawLineWithIntervalsAndPadding(string characterToDraw, int drawingLength, int paddingLength)
        {
            var rowToDraw = String.Join(" ", new string('*', drawingLength).ToCharArray());
            return rowToDraw.PadLeft(paddingLength + rowToDraw.Length);
        }
    }
}
