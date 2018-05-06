using System;
using System.Linq;

namespace _02_change_list
{
    class ChangeList
    {
        static void Main()
        {
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(' ');
            while (true)
            {
                switch (command[0])
                {
                    case "Delete":
                        {
                            var element = int.Parse(command[1]);
                            elements.RemoveAll(x => x == element);
                            break;
                        }
                    case "Insert":
                        {
                            var element = int.Parse(command[1]);
                            var index = int.Parse(command[2]);
                            elements.Insert(index, element);
                            break;
                        }
                    case "Even":
                        {
                            var result = string.Join(" ", elements.Where(x => (x % 2 == 0)));
                            Console.WriteLine(result);
                            return;
                        }
                    case "Odd":
                        {
                            var result = string.Join(" ", elements.Where(x => (x % 2 != 0)));
                            Console.WriteLine(result);
                            return;
                        }
                }

                command = Console.ReadLine().Split(' ');
            }
        }
    }
}
/*

1 2 3 4 5 5 5 6
Delete 5
Insert 10 1
Delete 5
Odd

20 12 4 319 21 31234 2 41 23 4
Insert 50 2
Insert 50 5
Delete 4
Even

 */
