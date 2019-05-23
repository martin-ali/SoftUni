using System;
using System.Collections.Generic;

namespace _09_simple_text_editor
{
    class SimpleTextEditor
    {
        static void Main()
        {
            var operationsCount = int.Parse(Console.ReadLine());
            var textHistory = new Stack<string>();
            textHistory.Push(string.Empty);

            for (int i = 0; i < operationsCount; i++)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "1")
                {
                    var text = input[1];
                    textHistory.Push(textHistory.Peek() + text);
                }
                else if (input[0] == "2")
                {
                    var elementsToErase = int.Parse(input[1]);
                    var textToEdit = textHistory.Peek();
                    var editedText = textToEdit.Remove(textToEdit.Length - elementsToErase);

                    textHistory.Push(editedText);
                }
                else if (input[0] == "3")
                {
                    var index = int.Parse(input[1]) - 1;
                    Console.WriteLine(textHistory.Peek()[index]);
                }
                else if (input[0] == "4")
                {
                    textHistory.Pop();
                }
            }
        }
    }
}
