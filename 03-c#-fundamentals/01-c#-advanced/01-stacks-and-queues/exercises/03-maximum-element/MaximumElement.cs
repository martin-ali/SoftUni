using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_maximum_element
{
    class MaximumElement
    {
        static void Main()
        {
            var commandCount = int.Parse(Console.ReadLine());
            var elements = new Stack<int>();

            var maxStack = new Stack<int>();
            maxStack.Push(int.MinValue);
            for (int i = 0; i < commandCount; i++)
            {
                var commandParts = Console.ReadLine().Split();
                var command = commandParts[0];

                if (command == "1")
                {
                    var element = int.Parse(commandParts[1]);
                    elements.Push(element);

                    if (element >= maxStack.Peek())
                    {
                        maxStack.Push(element);
                    }
                }
                else if (command == "2" && elements.Count > 0)
                {
                    var element = elements.Pop();
                    if (maxStack.Peek() == element)
                    {
                        maxStack.Pop();
                    }
                }
                else if (command == "3")
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}