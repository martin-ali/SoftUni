using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_basic_queue_operations
{
    class BasicQueueOperations
    {
        static void Main()
        {
            var parameters = Console
                            .ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            var elementsToEnqueue = parameters[0];
            var elementsToDequeue = parameters[1];
            var elementToFind = parameters[2];

            var elementsArray = Console
                            .ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            var elementsQueue = new Queue<int>();
            for (int i = 0; i < elementsToEnqueue; i++)
            {
                elementsQueue.Enqueue(elementsArray[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                elementsQueue.Dequeue();
            }

            var result = "0";
            if (elementsQueue.Contains(elementToFind))
            {
                result = "true";
            }
            else if (elementsQueue.Count > 0)
            {
                result = elementsQueue.Min().ToString();
            }

            Console.WriteLine(result);
        }
    }
}
