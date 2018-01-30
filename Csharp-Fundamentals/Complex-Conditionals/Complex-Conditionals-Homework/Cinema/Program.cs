using System;

namespace Cinema
{
    class Program
    {
        static void Main()
        {
            var projectionType = Console.ReadLine().ToLower();
            var rowCount = int.Parse(Console.ReadLine());
            var colCount = int.Parse(Console.ReadLine());

            var rate = 0d;

            if (projectionType == "premiere")
            {
                rate = 12;
            }
            else if (projectionType == "normal")
            {
                rate = 7.5;
            }
            else if (projectionType == "discount")
            {
                rate = 5;
            }

            var result = rate * rowCount * colCount;
            Console.WriteLine($"{result:0.00} leva");
        }
    }
}
