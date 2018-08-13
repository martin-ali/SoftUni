using System;

namespace House
{
    class Program
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var roofSize = Math.Ceiling(size / 2m);
            var baseSize = Math.Floor(size / 2m);

            // Draw roof
            for (int current = 0, roofWidth = size % 2 == 0 ? 2 : 1; current < roofSize; current++, roofWidth += 2)
            {
                var leaves = new string('*', roofWidth);
                var padding = new string('-', (size - leaves.Length) / 2);

                Console.WriteLine($"{padding}{leaves}{padding}");
            }

            // Draw base
            for (int current = 0; current < baseSize; current++)
            {
                var leaves = new string('*', size - 2);
                Console.WriteLine($"|{leaves}|");
            }
        }
    }
}
