using System;
using System.Linq;

namespace _02_icarus
{
    class Program
    {
        static void Main()
        {
            var damage = 1;
            var plane = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).Select(int.Parse).ToArray();
            var icarusPosition = int.Parse(Console.ReadLine());

            var commandRaw = Console.ReadLine().ToLower();
            while (commandRaw != "supernova")
            {
                var commandData = commandRaw.Split(new char[] { ' ' }, StringSplitOptions.None);
                var command = (direction: commandData[0], steps: int.Parse(commandData[1]));

                if (command.direction == "left")
                {
                    for (int count = 0; count < command.steps; count++)
                    {
                        icarusPosition--;
                        if (icarusPosition < 0)
                        {
                            icarusPosition = plane.Length - 1;
                            damage++;
                        }

                        plane[icarusPosition] -= damage;
                    }
                }
                else
                {
                    for (int count = 0; count < command.steps; count++)
                    {
                        icarusPosition++;
                        if (icarusPosition >= plane.Length)
                        {
                            icarusPosition = 0;
                            damage++;
                        }

                        plane[icarusPosition] -= damage;
                    }
                }


                commandRaw = Console.ReadLine().ToLower();
            }

            Console.WriteLine(String.Join(" ", plane));
        }
    }
}
