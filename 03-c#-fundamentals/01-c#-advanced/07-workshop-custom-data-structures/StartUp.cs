using System;

namespace create_custom_data_structures
{
    class StartUp
    {
        static void Main()
        {
            // List
            var list = new CustomList<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            // Console.WriteLine(list.RemoveAt(0));
            // Console.WriteLine(list.Contains(3));
            // list.Swap(0, 1);

            // foreach (var item in list)
            // {
            //     Console.WriteLine(item);
            // }

            // Stack testing
            var stack = new CustomStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            // Console.WriteLine(stack.Pop());
            // Console.WriteLine(stack.Pop());
            // Console.WriteLine(stack.Pop());

            // stack.Pop();
            // stack.Pop();
            // stack.Pop();

            // Console.WriteLine(stack.Peek());
            // Console.WriteLine(stack.Peek());
            // Console.WriteLine(stack.Peek());

            // stack.ForEach(Console.WriteLine);

            // foreach (var item in stack)
            // {
            //     Console.WriteLine(item);
            // }
        }
    }
}
