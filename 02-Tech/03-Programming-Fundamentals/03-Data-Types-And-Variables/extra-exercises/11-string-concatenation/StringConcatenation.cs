using System;
using System.Text;

namespace _11_string_concatenation
{
    class StringConcatenation
    {
        static void Main()
        {
            var delimiter = char.Parse(Console.ReadLine());
            var lineParity = Console.ReadLine();
            var numberOfLines = int.Parse(Console.ReadLine());

            if (lineParity == "even") Console.ReadLine();

            var builder = new StringBuilder();
            for (int i = 0; i < numberOfLines / 2; i++)
            {
                // Get line we need
                var current = Console.ReadLine();
                builder.Append(current + delimiter);

                // Waste next line since we don't need it
                Console.ReadLine();
            }

            // Get rid of last delimiter
            builder.Remove(builder.Length - 1, 1);
            Console.WriteLine(builder);
        }
    }
}
