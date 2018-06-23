using System;

namespace _18_different_integer_sizes
{
    class DifferentIntegerSizes
    {
        static void Main()
        {
            var numberString = Console.ReadLine();
            long number;
            var isValidNumber = long.TryParse(numberString, out number);
            if (isValidNumber == false)
            {
                Console.WriteLine($"{numberString} can't fit in any type");
                return;
            }

            var typesAndLimits = new(string name, long max, long min)[]
            {
                (name: "sbyte", max: sbyte.MaxValue, min: sbyte.MinValue),
                (name: "byte", max: byte.MaxValue, min: byte.MinValue),
                (name: "short", max: short.MaxValue, min: short.MinValue),
                (name: "ushort", max: ushort.MaxValue, min: ushort.MinValue),
                (name: "int", max: int.MaxValue, min: int.MinValue),
                (name: "uint", max: uint.MaxValue, min: uint.MinValue),
                (name: "long", max: long.MaxValue, min: long.MinValue)
            };

            Console.WriteLine($"{number} can fit in:");
            for (int current = 0; current < typesAndLimits.Length; current++)
            {
                var currentType = typesAndLimits[current];

                if (currentType.min <= number && number <= currentType.max)
                {
                    Console.WriteLine($"* {currentType.name}");
                }
            }

        }
    }
}
