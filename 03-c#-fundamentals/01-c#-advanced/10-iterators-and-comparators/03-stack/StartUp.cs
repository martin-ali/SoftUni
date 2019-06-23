using System;
using System.Linq;

namespace _03_stack
{
    class StartUp
    {
        static void Main()
        {
            var stack = new Stack<int>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                if (input.Contains("Push"))
                {
                    var items = input
                                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Skip(1)
                                .Select(int.Parse);

                    stack.Push(items);
                }
                else if (input == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                input = Console.ReadLine();
            }

            PrintStack(stack);
            PrintStack(stack);
        }

        private static void PrintStack<T>(Stack<T> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
