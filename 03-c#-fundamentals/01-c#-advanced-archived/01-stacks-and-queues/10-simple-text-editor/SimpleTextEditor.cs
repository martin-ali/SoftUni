using System;
using System.Collections.Generic;
using System.Text;

namespace _10_simple_text_editor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            var text = new StringBuilder();
            // Could be done with command object, that keeps the change, and the operation type, which can then be inverted
            var history = new Stack<string>();

            var commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                var commandParts = Console.ReadLine().Split();
                var command = commandParts[0];

                if (command == "1")
                {
                    history.Push(text.ToString());

                    var textToAppend = commandParts[1];
                    text.Append(textToAppend);
                }
                else if (command == "2")
                {
                    history.Push(text.ToString());

                    var elementCountToRemove = int.Parse(commandParts[1]);
                    text.Remove(text.Length - elementCountToRemove, elementCountToRemove);
                }
                else if (command == "3")
                {
                    var position = int.Parse(commandParts[1]) - 1;
                    Console.WriteLine(text[position]);
                }
                else if (command == "4")
                {
                    if (history.Count > 0)
                    {
                        text = new StringBuilder(history.Pop());
                    }
                }
            }
        }
    }
}
/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4
3 1
 */
