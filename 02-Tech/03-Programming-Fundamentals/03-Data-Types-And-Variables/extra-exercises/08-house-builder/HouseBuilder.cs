using System;

namespace _08_house_builder
{
    class HouseBuilder
    {
        static void Main()
        {
            var firstNumber = long.Parse(Console.ReadLine());
            var secondNumber = long.Parse(Console.ReadLine());

            var integerNumber = Math.Max(firstNumber, secondNumber);
            var sbyteNumber = Math.Min(firstNumber, secondNumber);

            var materialsPrice = (10 * integerNumber) + (4 * sbyteNumber);
            Console.WriteLine(materialsPrice);
        }
    }
}
