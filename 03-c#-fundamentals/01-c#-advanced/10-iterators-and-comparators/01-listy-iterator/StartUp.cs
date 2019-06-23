using System;
using System.Linq;

namespace _01_listy_iterator
{
    class StartUp
    {
        static void Main()
        {
            var items = Console.ReadLine()
                        .Split()
                        .Skip(1);
            var iterator = new ListyIterator<string>(items);

            var input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "Move")
                {
                    Console.WriteLine(iterator.Move());
                }
                else if (input == "Print")
                {
                    try
                    {
                        // Not printing directly, because that would be coupling
                        Console.WriteLine(iterator.Print());
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(iterator.HasNext());
                }

                input = Console.ReadLine();
            }
        }
    }
}
