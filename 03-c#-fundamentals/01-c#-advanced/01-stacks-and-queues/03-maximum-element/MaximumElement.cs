using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_maximum_element
{
    class MaximumElement
    {
        static void Main()
        {
            var commandCount = int.Parse(Console.ReadLine());
            var elements = new Stack<int>();
            var maxElementsBuilder = new StringBuilder();
            var maxElements = new Stack<int>();
            maxElements.Push(int.MinValue);

            for (int i = 0; i < commandCount; i++)
            {
                var commandParts = Console.ReadLine().Split();
                var command = commandParts[0];

                if (command == "1")
                {
                    var element = int.Parse(commandParts[1]);
                    elements.Push(element);

                    if (element >= maxElements.Peek())
                    {
                        maxElements.Push(element);
                    }
                }
                else if (command == "2" && elements.Count > 0)
                {
                    var element = elements.Pop();
                    if (maxElements.Peek() == element)
                    {
                        maxElements.Pop();
                    }
                }
                else if (command == "3")
                {
                    maxElementsBuilder.AppendLine(maxElements.Peek().ToString());
                    // builder.Append($"{maxStack.Peek()}{Environment.NewLine}");
                }
            }

            Console.WriteLine(maxElementsBuilder.ToString());
        }
    }
}