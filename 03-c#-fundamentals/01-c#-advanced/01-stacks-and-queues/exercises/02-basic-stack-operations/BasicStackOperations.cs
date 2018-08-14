using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_basic_stack_operations
{
    class BasicStackOperations
    {
        static void Main()
        {
            var parameters = Console
                            .ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            var elementsToPush = parameters[0];
            var elementsToPop = parameters[1];
            var elementToFind = parameters[2];

            var elementsArray = Console
                            .ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            var elementsStack = new Stack<int>();
            for (int i = 0; i < elementsToPush; i++)
            {
                elementsStack.Push(elementsArray[i]);
            }

            while (elementsToPop-- > 0)
            {
                elementsStack.Pop();
            }

            var result = "0";
            if (elementsStack.Contains(elementToFind))
            {
                result = "true";
            }
            else if (elementsStack.Count() > 0)
            {
                result = elementsStack.Min().ToString();
            }

            Console.WriteLine(result);
        }
    }
}
