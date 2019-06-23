using System;
using System.Linq;

namespace _02_collection
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
                else if (input == "PrintAll")
                {
                    Console.WriteLine(iterator.PrintAll());
                }

                input = Console.ReadLine();
            }
        }
    }
}
