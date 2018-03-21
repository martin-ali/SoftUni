using System;
using System.Linq;

namespace _04_hornet_assault
{
    class Program
    {
        static void Main()
        {
            var beehives = Console
                            .ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.None)
                            .Select(long.Parse)
                            .ToList();
            var hornets = Console
                            .ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.None)
                            .Select(long.Parse)
                            .ToList();

            for (int current = 0; current < beehives.Count; current++)
            {
                var hornetsPower = hornets.Sum();

                if (beehives[current] >= hornetsPower && hornets.Count > 0)
                {
                    hornets.RemoveAt(0);
                }

                beehives[current] -= hornetsPower;
            }

            var survivorHives = beehives.Where(x => x > 0);
            if (survivorHives.Count() > 0)
            {
                Console.WriteLine(String.Join(" ", survivorHives));
            }
            else
            {
                Console.WriteLine(String.Join(" ", hornets));
            }
        }
    }
}
