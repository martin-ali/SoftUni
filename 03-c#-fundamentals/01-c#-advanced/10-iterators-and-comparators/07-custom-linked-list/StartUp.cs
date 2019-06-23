using System;

namespace _07_custom_linked_list
{
    class StartUp
    {
        static void Main()
        {
            var list = new DoublyLinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            list.AddLast(11);
            list.AddLast(22);
            list.AddLast(33);

            list.RemoveFirst();
            list.RemoveLast();

            list.ForEach(Console.WriteLine);

            Console.WriteLine();

            foreach (var element in list.ToArray())
            {
                Console.WriteLine(element);
            }
        }
    }
}
