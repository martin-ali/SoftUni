using System;
using System.Collections.Generic;

namespace _05_calculate_sequence_with_queue
{
    class CalculateSequenceWithQueue
    {
        static void Main()
        {
            var startingNumber = long.Parse(Console.ReadLine());

            var numbers = new Queue<long>();
            numbers.Enqueue(startingNumber);

            var currentNumber = numbers.Peek();
            Console.Write($"{currentNumber} ");
            for (int i = 0; i < 48; i += 3)
            {
                currentNumber = numbers.Dequeue();

                long first = currentNumber + 1;
                long second = (2 * currentNumber) + 1;
                long third = currentNumber + 2;

                numbers.Enqueue(first);
                numbers.Enqueue(second);
                numbers.Enqueue(third);

                Console.Write($"{first} {second} {third} ");
            }

            currentNumber = numbers.Dequeue();
            Console.Write($"{currentNumber + 1}");
        }
    }
}
