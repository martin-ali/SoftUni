using System;

namespace _10_multiplication_table_2
{
    class MultiplicationTableTwo
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int current = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine($"{number} X {current} = {number * current}");
                current++;
            } while (current <= 10);
        }
    }
}
